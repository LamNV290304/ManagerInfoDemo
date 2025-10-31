using Microsoft.EntityFrameworkCore;
using ManagerInfoDemo.Models;
using ManagerInfoDemo.Repositories.Interface;

namespace ManagerInfoDemo.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ManagerInfoContext _managerInfoContext;

        public TokenRepository(ManagerInfoContext managerInfoContext)
        {
            _managerInfoContext = managerInfoContext;
        }

        public bool IsTokenValid(string email, string token)
        {
            var existingToken = _managerInfoContext.Tokens
                .AsNoTracking()
                .FirstOrDefault(t => t.Email == email && t.Token1 == token && t.Status == false && t.ExpiresAt > DateTime.UtcNow);

            if (existingToken == null) return false;

            existingToken.Status = true;
            _managerInfoContext.Update(existingToken);
            _managerInfoContext.SaveChanges();
            return true;
        }


        public void SaveToken(string email, string token, DateTime expireTime)
        {
            var existing = _managerInfoContext.Tokens.FirstOrDefault(t => t.Email == email);
            if (existing != null)
            {
                existing.Token1 = token;
                existing.ExpiresAt = expireTime;
                existing.Status = false;
                _managerInfoContext.Update(existing);
            }
            else
            {
                var newToken = new Token
                {
                    Email = email,
                    Token1 = token,
                    ExpiresAt = expireTime,
                    Status = false
                };
                _managerInfoContext.Tokens.Add(newToken);
            }

            _managerInfoContext.SaveChanges();
        }
    }
}
