using ManagerInfoDemo.Models;
using ManagerInfoDemo.Repositories.Interface;
using ManagerInfoDemo.Services.Interfaces;

namespace ManagerInfoDemo.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public bool ChangePassword(int id, string newPasswordHash)
        {
            return _staffRepository.ChangePassword(id, newPasswordHash);
        }

        public Staff? GetUserByEmail(string email)
        {
            return _staffRepository.GetUserByEmail(email);
        }

        public Staff? GetUserById(int id)
        {
            return _staffRepository.GetUserById(id);
        }

        public Staff? GetUserByUsername(string username)
        {
            return _staffRepository.GetUserByUsername(username);
        }

        public bool ResetPassword(string email, string passwordHash)
        {
            return _staffRepository.ResetPassword(email, passwordHash);
        }
    }
}
