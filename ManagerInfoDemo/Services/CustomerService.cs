using System;
using System.Collections.Generic;
using System.Linq;
using ManagerInfoDemo.Models;
using ManagerInfoDemo.Repositories.Interface;
using ManagerInfoDemo.Services.Interfaces;

namespace ManagerInfoDemo.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Customer> GetAll(string? keyword = null, bool? isVerify = null)
        {
            var query = _repository.GetQuery();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(c =>
                    (c.FullName != null && c.FullName.Contains(keyword)) ||
                    (c.Email != null && c.Email.Contains(keyword)) ||
                    (c.Phone != null && c.Phone.Contains(keyword)));
            }

            if (isVerify.HasValue)
            {
                query = query.Where(c => c.IsVerify == isVerify.Value);
            }

            return query
                .OrderByDescending(c => c.CreatedAt)
                .ToList();
        }

        public Customer? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Create(Customer customer)
        {
            _repository.Add(customer);
            _repository.SaveChanges();
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
            existing.IsVerify = customer.IsVerify;

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
    }
}
