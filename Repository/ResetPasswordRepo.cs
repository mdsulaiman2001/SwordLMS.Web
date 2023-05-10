using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SwordLMS.Web.Models;

namespace SwordLMS.Web.Repository
{
    public class PasswordTokenService : IPasswordResetRepo
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly SwordLmsContext _context;

        public PasswordTokenService(IDataProtectionProvider dataProtectionProvider, SwordLmsContext context)
        {
            _dataProtectionProvider = dataProtectionProvider;
            _context = context;
        }

        public string GeneratePasswordToken(User users)
        {
            var protector = _dataProtectionProvider.CreateProtector("PasswordResetToken");
              var token = $"{users.Email}";
            return protector.Protect(token);
        }
        public string GenerateEmailToken(string email )
        {
            var protector = _dataProtectionProvider.CreateProtector("EmailConfirmationToken");
           
            return protector.Protect(email);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

    }
}
