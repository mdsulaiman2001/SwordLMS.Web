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

namespace SwordLMS.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly SwordLmsContext _context;
        private readonly IPasswordHasher _passWordHasher;


        public UserController(SwordLmsContext context,
           IPasswordHasher passoWordHasher)
        {
            _context = context;
            _passWordHasher = passoWordHasher;


        }


        public IActionResult SignUp()
        {
            //ViewData["countries"] = new SelectList(_context.Countries.ToList(), "Id", "Name");
            //ViewData["states"] = new SelectList(_context.States.ToList(), "Id", "Name");

            return View();

        }


        //public JsonResult GetStates(int id)
        //{
        //    var states = _context.States.Where(x => x.Country.Id == id).OrderBy(x => x.Name).ToList();
        //    return new JsonResult(states);
        //}
        //public JsonResult GetCities(int id)
        //{
        //    var cities = _context.Cities.Where(x => x.State.Id == id).OrderBy(x => x.Name).ToList();
        //    return new JsonResult(cities);
        //}


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



      

         public IActionResult ForgetPassword()
        {
            return View();
        }

        public async Task<IActionResult> DoForgetPassword(RegisterRequest registerRequest)
        {
            if (ModelState.IsValid)
            {

                var user = await _context.Users.FindAsync(registerRequest.Email);
                if (user != null)

                    var user.Email.Equals(user.Email);
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetlink = Url.Action("ResetPassword", "User", new { email = user.Email, token }, Request.Scheme);

                    //  _logger.Log(LogLevel.Warning, passwordResetlink);
                    return View("ForgetPasswordConfirmation");
                }
                return View("ForgetPasswordConfirmation");

            }
            return View(users);
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