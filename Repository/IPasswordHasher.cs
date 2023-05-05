using NuGet.Packaging.Signing;

namespace SwordLMS.Web.Repository
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool verify (string passwordHash , string inputPassword);
    }
}
