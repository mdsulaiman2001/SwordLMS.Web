using NuGet.Packaging.Signing;

namespace SwordLMS.Web.Services
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool verify(string passwordHash, string inputPassword);
    }
}
