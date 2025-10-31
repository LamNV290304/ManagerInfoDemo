using System.Collections.Generic;
using ManagerInfoDemo.Models;

namespace ManagerInfoDemo.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll(string? keyword = null, bool? isVerify = null);
        Customer? GetById(int id);
        bool Create(Customer customer);
        bool Update(Customer customer);
        bool Delete(int id);
    }
}
