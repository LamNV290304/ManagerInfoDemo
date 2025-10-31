using ManagerInfoDemo.Helper;
using ManagerInfoDemo.Models;
using ManagerInfoDemo.Repositories.Interface;
using ManagerInfoDemo.Services.Interfaces;
using ManagerInfoDemo.ViewModels;

namespace ManagerInfoDemo.Services
{
    public class AuthenService : IAuthenService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly ITokenRepository _tokenRepository;
        public AuthenService(IStaffRepository staffRepository, IHttpContextAccessor httpContextAccessor, ITokenRepository tokenRepository)
        {
            _staffRepository = staffRepository;
            _tokenRepository = tokenRepository;
        }
        public Staff DoLogin(LoginUserRequest loginRequest)
        {
            var user = _staffRepository.GetUserByUsernameOrEmail(loginRequest.Username);

            if (user == null || !PasswordHelper.VerifyPassword(loginRequest.Password, user.PasswordHash))
                return new Staff();

            return user;
        }

        public bool DoResetPassword(string email, string password)
        {
            return _staffRepository.ResetPassword(email, PasswordHelper.HashPassword(password));
        }

        public string SaveToken(string email)
        {
            var token = Guid.NewGuid().ToString();
            var expiration = DateTime.UtcNow.AddMinutes(30);
            _tokenRepository.SaveToken(email, token, expiration);

            return token;
        }

        public bool VerifyToken(string email, string token)
        {
            try
            {
                return _tokenRepository.IsTokenValid(email, token);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
