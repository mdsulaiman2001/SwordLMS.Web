using SwordLMS.Web.Models;
using SwordLMS.Web.Request;

namespace SwordLMS.Web.Services
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
    }
}
