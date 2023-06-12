using Microsoft.AspNetCore.DataProtection;
using NuGet.Common;

using SwordLMS.Web.Models;
using System.Security.Policy;
using System.Web.Mvc;

namespace SwordLMS.Web.Services
{
    public class PasswordReset : IPasswordReset
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly SwordLmsContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public PasswordReset(IDataProtectionProvider dataProtectionProvider, SwordLmsContext context, IPasswordHasher passwordHasher)
        {
            _dataProtectionProvider = dataProtectionProvider;
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public string GeneratePasswordToken(User users)
        {
            var protector = _dataProtectionProvider.CreateProtector("PasswordResetToken");
            var token = $"{users.Email}";
            return protector.Protect(token);
        }

        public string GenerateEmailToken(string email)
        {
            var protector = _dataProtectionProvider.CreateProtector("EmailConfirmationToken");

            return protector.Protect(email);
        }

        public string DoForgetPassword(ResetPassword model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

            if (user != null)
            {
                var token = GeneratePasswordToken(user);
                model.Token = token;
            }
            return model.Token;
            
        }
        public void ResetPassword(ResetPassword model)
        {
            var user = _context.Users.Single(u => u.Email == model.Email);
           
            if (user != null)
            {
                var passwordHash = _passwordHasher.Hash(model.Password);
                user.Password = passwordHash;
                
                _context.Users.Update(user);
                _context.SaveChanges();

            }
            return;
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
