using ManagerInfoDemo.Models;

namespace ManagerInfoDemo.Services.Interfaces
{
    public interface IStaffService
    {
        Staff? GetUserById(int id);
        Staff? GetUserByUsername(string username);
        Staff? GetUserByEmail(string email);
        bool ResetPassword(string email, string passwordHash);
        bool ChangePassword(int id, string newPasswordHash);
    }
}
