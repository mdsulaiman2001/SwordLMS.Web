using SwordLMS.Web.Models;

namespace SwordLMS.Web.Services
{
    public interface IPasswordReset
    {
        string GeneratePasswordToken(User users);

        string GenerateEmailToken(string email);

        Task<User> GetUserByEmailAsync(string email);

        void ResetPassword(ResetPassword model);

    }
}
