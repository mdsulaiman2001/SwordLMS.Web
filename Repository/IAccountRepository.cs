using SwordLMS.Web.Models;

namespace SwordLMS.Web.Repository
{
    public interface IAccountRepository
    {
        Task<User> GetUserByEmailAsync(string email);

        Task GenerateForgetPasswordTokenAsync(User user);
    }
}
