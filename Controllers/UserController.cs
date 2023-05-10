using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using NUnit.Framework;
using SwordLMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Session;
using System.Security.Cryptography;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Identity;
using SwordLMS.Web.Repository;
using SwordLMS.Web.Request;
using NuGet.Protocol.Plugins;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Identity.Client;
using NuGet.Common;
using System.Reflection.Metadata;

namespace SwordLMS.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly SwordLmsContext _context;
        private readonly IPasswordHasher _passWordHasher;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public UserController(SwordLmsContext context,
           IPasswordHasher passoWordHasher, IDataProtectionProvider dataProtectionProvider)
        {
            _context = context;
            _passWordHasher = passoWordHasher;
            _dataProtectionProvider = dataProtectionProvider;
        }


        public IActionResult SignUp()
        {
            //ViewData["countries"] = new SelectList(_context.Countries.ToList(), "Id", "Name");
            //ViewData["states"] = new SelectList(_context.States.ToList(), "Id", "Name");
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> SaveSignUp(RegisterRequest registerRequest)
        {
            //DateTime date= DateTime.Now;


            var dateTime = DateTime.Now.ToShortDateString();
            registerRequest.DateOfBirth = Convert.ToDateTime(dateTime);

            var passwordHash = _passWordHasher.Hash(registerRequest.Password);
            registerRequest.Password = passwordHash;

            //user.Password = Guid.NewGuid().ToString();

            string strDDLValue = Request.Form["ddlRole"].ToString();
            registerRequest.RoleId = Convert.ToInt32(strDDLValue);

            var user = new User
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                UserName = registerRequest.UserName,
                Password = registerRequest.Password,
                RoleId = registerRequest.RoleId,
                DateOfBirth = registerRequest.DateOfBirth,
                Address = registerRequest.Address,
                Pincode = registerRequest.Pincode,
                State = registerRequest.State,
                Country = registerRequest.Country,
                City = registerRequest.City,
                PhoneNumber = registerRequest.PhoneNumber,

            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com");
                //client.Connect("server33.somewebhosting.com", 465);
                client.Authenticate("mdsulaiman2k00@gmail.com", "xeqidskmouhovsni");

                var FullName = user.FirstName + " " + user.LastName;

                var bodybuilder = new BodyBuilder
                {
                    HtmlBody = $"<p>Welcome {FullName},</p> Thank you for registering with us.",
                    TextBody = "{user.Name} \r\n"
                };
                var message = new MimeMessage
                {
                    Body = bodybuilder.ToMessageBody(),
                };
                message.From.Add(new MailboxAddress("SwordLMS", "mdsulaiman2k00@gmail.com"));
                message.To.Add(new MailboxAddress(FullName, user.Email));
                message.Subject = "Registration Successful";
                client.Send(message);

                client.Disconnect(true);


            }

            return RedirectToAction("Login");
        }
        public string GeneratePasswordToken(User users)
        {
            var protector = _dataProtectionProvider.CreateProtector("PasswordResetToken");
            var token = $"{users.Email}";
            return protector.Protect(token);
        }
        //public string GenerateEmailToken(string email)
        //{
        //    var protector = _dataProtectionProvider.CreateProtector("EmailConfirmationToken");

        //    return protector.Protect(email);
        //}


        //public async Task<IActionResult> ResetPasswordAsync(string email , string token , string password)
        //{
        //    //var user = await _context.Users.SingleOrDefaultAsync(user, model.email);
        //    return await _context.(await _context.FindAsync(email , token, password));

        //}

        //public  async Task<IActionResult> ResetPasswordByAsync(string email, string newPassword, string resetToken)
        //{
        //    return (await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

    
           
        //}

        //public async Task<User> ResetPasswordByAsync(string email, string newPassword, string resetToken)
        //{
                   
        //        return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            
        //}



        public IActionResult ForgetPassword()
        {
            return View();
        }

       
        public IActionResult DoForgetPassword(ForgetPassword model)
        {
          
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            //if (user == null)
            //{
            //    ViewData["EmailErr"] = "Email Address Does'nt Match";
            //    return View("ForgetPassword");
               
            //}
            if (user != null)
            {
                var token = GeneratePasswordToken(user);
                var passwordResetlink = Url.Action("ResetPassword", "User", new { email = user.Email, token }, Request.Scheme);
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com");
                    //client.Connect("server33.somewebhosting.com", 465);
                    client.Authenticate("mdsulaiman2k00@gmail.com", "xeqidskmouhovsni");

                    var FullName = user.FirstName + " " + user.LastName;

                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"<p>Hello, {FullName},</p> <p>Here is a link to ResetPassword</p> {passwordResetlink}",
                        TextBody = "{user.Name} \r\n"
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody(),
                    };
                    message.From.Add(new MailboxAddress("SwordLMS", "mdsulaiman2k00@gmail.com"));
                    message.To.Add(new MailboxAddress(FullName, user.Email));
                    message.Subject = "Reset Password!";
                    client.Send(message);

                    client.Disconnect(true);
                    ModelState.Clear();
                    model.EmailSent = true;
                    TempData["MailMessage"] = "We Have Sent Reset Password Link To The Registered Email Address, Kindly Reset The Password Using The Link"; 
                }
            }


            else
                TempData["EmailErr"] = "Email Address Does'nt Match";
                return View("ForgetPassword");
            
            
           // return View("ForgetPassword");
        }

        public async Task<IActionResult> DoLoginAsync(LoginRequest loginRequest)
        {
            if (loginRequest == null)
                return BadRequest();
            //var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginRequest.UserName);



            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(m => m.UserName == loginRequest.UserName);


            if (user == null)
                return NotFound(new { Message = "User not found" });

            if (!_passWordHasher.verify(user.Password, loginRequest.Password))
            {
                //var loggerUser = _context.Users.Where(m => m.UserName.Equals(user.UserName) && m.Password.Equals(user.Password)).Include(r => r.Role).FirstOrDefault();


                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("userid", user.Id.ToString()),
                    new Claim("FullName", user.FirstName +" "+ user.LastName),
                    new Claim(ClaimTypes.Role, user.Role.Name),

                };
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                //--------------------------------------------------------
                TempData["UserName"] = user.UserName;
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                TempData["LoginErr"] = "Wrong credentials. Please, try again!";
                return View("Login");
            }


        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            // HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

      public IActionResult ResetPassword(string email , string token )
        {
            ResetPassword resetPasswordModel = new ResetPassword
            {
                Token = token,
                Email = email
            };
            return View();
        }



        public IActionResult DoResetPassword(ResetPassword model)
        {
            if (ModelState.IsValid)
            {


                var user = _context.Users.Single(u => u.Email == model.Email);
                if (user != null)
                {
                    //var result = ResetPasswordByAsync(model.Email ,model.Token, model.Password);

                    var passwordHash = _passWordHasher.Hash(user.Password);
                    user.Password = passwordHash;
                    _context.Users.Update(user);
                    _context.SaveChangesAsync();
                    TempData["PasswordChanged"] = "you have successfully changed the password, you can login with New Password";
                    return View("ResetPassword");

                }
               
            }
            TempData["PasswordErr"] = "password does not matches";
            return View("ResetPassword");
        }

        [Authorize]
        public IActionResult HomePage()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}