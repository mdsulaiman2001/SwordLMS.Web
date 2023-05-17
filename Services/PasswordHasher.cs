using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tls;
using System.Security.Cryptography;


namespace SwordLMS.Web.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int saltSize = 128 / 8;
        private const int keySize = 256 / 8;
        private const int iteration = 10000;
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
        private const char delimeter = ';';

        public string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(saltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iteration, _hashAlgorithmName, keySize);
            return string.Join(delimeter, Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        public bool verify(string passwordHash, string inputPassword)
        {
            var elements = passwordHash.Split(delimeter);


            var salt = Convert.FromBase64String(elements[0]);
            var hash = Convert.FromBase64String(elements[1]);
            var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, keySize, _hashAlgorithmName, iteration);
            return CryptographicOperations.FixedTimeEquals(hash, hashInput);

        }
    }
}

