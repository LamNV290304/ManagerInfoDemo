using System.Linq;
using ManagerInfoDemo.Models;

namespace ManagerInfoDemo.Repositories.Interface
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetQuery();
        Customer? GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        void SaveChanges();
    }
}
