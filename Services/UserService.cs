using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SwordLMS.Web.Models;
using SwordLMS.Web.Request;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Web.Mvc;


namespace SwordLMS.Web.Services
{
    public class UserService : IUserService
    {
        private readonly SwordLmstwoContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(SwordLmstwoContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public User GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {             

                throw new Exception("User Not Found");
            }
            else
                return user;

            //return _context.Users.FirstOrDefault(u => u.Email == email);
        }

       



    }

}
