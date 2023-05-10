using SwordLMS.Web.Models;

namespace SwordLMS.Web.Repository
{
    public interface IPasswordResetRepo
    {
        string GeneratePasswordToken(User users);

        string GenerateEmailToken(string email);

         Task<User> GetUserByEmailAsync(string email);

    }
}
