using ManagerInfoDemo.Models;

namespace ManagerInfoDemo.Repositories.Interface
{
    public interface IStaffRepository
    {
        Staff? GetUserById(int id);
        Staff? GetUserByUsernameOrEmail(string username);
        Staff? GetUserByEmail(string email);
        bool ResetPassword(string email, string passwordHash);
        bool ChangePassword(int id, string newPasswordHash);
    }
}
