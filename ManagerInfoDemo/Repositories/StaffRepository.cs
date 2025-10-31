using System;
using ManagerInfoDemo.Models;
using ManagerInfoDemo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ManagerInfoDemo.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ManagerInfoContext _context;

        public StaffRepository(ManagerInfoContext context)
        {
            _context = context;
        }

        public Staff? GetUserById(int id)
        {
            return _context.Staffs.FirstOrDefault(s => s.Id == id);
        }

        public Staff? GetUserByUsername(string username)
        {
            return _context.Staffs.FirstOrDefault(s => s.Username == username);
        }

        public Staff? GetUserByEmail(string email)
        {
            return _context.Staffs.FirstOrDefault(s => s.Email == email);
        }

        public bool ResetPassword(string email, string passwordHash)
        {
            var staff = _context.Staffs.FirstOrDefault(s => s.Email == email);
            if (staff == null)
                return false;

            staff.PasswordHash = passwordHash;
            _context.SaveChanges();
            return true;
        }

        public bool ChangePassword(int id, string newPasswordHash)
        {
            var staff = _context.Staffs.FirstOrDefault(s => s.Id == id);
            if (staff == null)
                return false;

            staff.PasswordHash = newPasswordHash;
            _context.SaveChanges();
            return true;
        }
    }
}
