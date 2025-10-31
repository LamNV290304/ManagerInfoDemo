using System.Linq;
using ManagerInfoDemo.Models;
using ManagerInfoDemo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ManagerInfoDemo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ManagerInfoContext _context;

        public CustomerRepository(ManagerInfoContext context)
        {
            _context = context;
        }

        public IQueryable<Customer> GetQuery()
        {
            return _context.Customers.AsNoTracking();
        }

        public Customer? GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer? GetByEmail(string email)
        {
            return _context.Customers.FirstOrDefault(c => c.Email == email);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
