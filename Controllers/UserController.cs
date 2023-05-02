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

namespace SwordLMS.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly SwordLmsContext _context;
        //private readonly SwordLmsContext db;


        public UserController(SwordLmsContext context)
        {
            _context = context;
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
        public async Task<IActionResult> SaveSignUp(User user)
        {
            //DateTime date= DateTime.Now;

            var dateTime = DateTime.Now.ToShortDateString();
            user.DateOfBirth = Convert.ToDateTime(dateTime);

           //user.Password = Guid.NewGuid().ToString();

            string strDDLValue = Request.Form["ddlRole"].ToString();
            user.RoleId = Convert.ToInt32(strDDLValue);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com");
                //client.Connect("server33.somewebhosting.com", 465);
                client.Authenticate("mdsulaiman2k00@gmail.com", "xeqidskmouhovsni");

                var FullName =user.FirstName +" "+ user.LastName;

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


                return RedirectToAction("Login");

            }
        }

        //public void SetPassword(string Password)
        //{
        //   _context.Users.Password = CryptoConfig.
        //}

        public async Task<IActionResult> DoLoginAsync(User user)
        {

                var loggerUser = _context.Users.Where(m => m.UserName.Equals(user.UserName) && m.Password.Equals(user.Password)).Include(r => r.Role).FirstOrDefault();
                if (loggerUser != null)
                {

                //--------------------------------------------------------
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loggerUser.Email),
                    new Claim("userid", loggerUser.Id.ToString()),
                    new Claim("FullName", loggerUser.FirstName +" "+ loggerUser.LastName),
                    new Claim(ClaimTypes.Role, loggerUser.Role.Name),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                //--------------------------------------------------------


                TempData["UserName"] = loggerUser.UserName;
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