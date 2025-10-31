using ManagerInfoDemo.Models;
using ManagerInfoDemo.ViewModels;

namespace ManagerInfoDemo.Services.Interfaces
{
    public interface ICustomerService
    {
        CustomerListResult GetPaged(string? keyword = null, bool? isVerify = null, int page = 1, int pageSize = 10);
        Customer? GetById(int id);
    bool Create(Customer customer, out string? verificationToken, out string? errorMessage);
    bool Update(Customer customer, out string? errorMessage);
        bool Delete(int id);
        bool VerifyCustomer(string email, string token);
    }
}
