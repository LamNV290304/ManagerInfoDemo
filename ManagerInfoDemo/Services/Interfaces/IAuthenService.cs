using ManagerInfoDemo.Models;
using ManagerInfoDemo.ViewModels;

namespace ManagerInfoDemo.Services.Interfaces
{
    public interface IAuthenService
    {
        Staff DoLogin(LoginUserRequest loginRequest);
        string SaveToken(string email);
        bool VerifyToken(string email, string token);
        bool DoResetPassword(string email, string password);
    }
}
