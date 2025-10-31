using System;
using System.Linq;
using ManagerInfoDemo.Models;
using ManagerInfoDemo.Repositories.Interface;
using ManagerInfoDemo.Services.Interfaces;
using ManagerInfoDemo.ViewModels;

namespace ManagerInfoDemo.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly ITokenRepository _tokenRepository;

        public CustomerService(ICustomerRepository repository, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _tokenRepository = tokenRepository;
        }

        private IQueryable<Customer> BuildQuery(string? keyword, bool? isVerify)
        {
            var query = _repository.GetQuery();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var trimmedKeyword = keyword.Trim();
                query = query.Where(c =>
                    (c.FullName != null && c.FullName.Contains(trimmedKeyword)) ||
                    (c.Email != null && c.Email.Contains(trimmedKeyword)) ||
                    (c.Phone != null && c.Phone.Contains(trimmedKeyword)));
            }

            if (isVerify.HasValue)
            {
                query = query.Where(c => c.IsVerify == isVerify.Value);
            }

            return query;
        }

        public CustomerListResult GetPaged(string? keyword = null, bool? isVerify = null, int page = 1, int pageSize = 10)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 10 : pageSize;

            var query = BuildQuery(keyword, isVerify);
            var totalItems = query.Count();

            var items = query
                .OrderByDescending(c => c.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new CustomerListResult
            {
                Items = items,
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                Keyword = keyword,
                IsVerify = isVerify
            };
        }

        public Customer? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Create(Customer customer, out string? verificationToken)
        {
            verificationToken = null;
            customer.CreatedAt ??= DateTime.Now;
            customer.IsVerify = false;
            _repository.Add(customer);
            _repository.SaveChanges();

            if (!string.IsNullOrWhiteSpace(customer.Email))
            {
                verificationToken = Guid.NewGuid().ToString();
                _tokenRepository.SaveToken(customer.Email, verificationToken, DateTime.UtcNow.AddDays(1));
            }

            return true;
        }

        public bool Update(Customer customer)
        {
            var existing = _repository.GetById(customer.Id);
            if (existing == null)
            {
                return false;
            }

            existing.FullName = customer.FullName;
            existing.Email = customer.Email;
            existing.Phone = customer.Phone;
            existing.Address = customer.Address;
            existing.DateOfBirth = customer.DateOfBirth;

            _repository.Update(existing);
            _repository.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                return false;
            }

            _repository.Delete(existing);
            _repository.SaveChanges();

            return true;
        }

        public bool VerifyCustomer(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
            {
                return false;
            }

            var isValid = _tokenRepository.IsTokenValid(email, token);
            if (!isValid)
            {
                return false;
            }

            var customer = _repository.GetByEmail(email);
            if (customer == null)
            {
                return false;
            }

            customer.IsVerify = true;
            _repository.Update(customer);
            _repository.SaveChanges();

            return true;
        }
    }
}
