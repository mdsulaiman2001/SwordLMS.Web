using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using SwordLMS.Web.Models;
using System.Collections.Generic;
using System.Diagnostics;

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
           ViewData["countries"] = new SelectList(_context.Countries.ToList(), "Id", "Name");
            //ViewData["states"] = new SelectList(_context.States.ToList(), "Id", "Name");

            return View();

        }


        public JsonResult GetStates(int id)
        {
            var states = _context.States.Where(x => x.Country.Id == id).OrderBy(x => x.Name).ToList();
            return new JsonResult(states);
        }
        public JsonResult GetCities(int id)
        {
            var cities = _context.Cities.Where(x => x.State.Id == id).OrderBy(x => x.Name).ToList();
            return new JsonResult(cities);
        }


        public IActionResult Login()
        {
            User _user = new User();
            var roles = _context.Roles.ToList();
            ViewBag.roles = _context.Roles.ToList();
            return View();
        }
        public async Task<IActionResult> SaveSignUp(User user)
        {
           
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
        }
        public IActionResult SaveLogin(User user)
        {
            var status = _context.Users.Where(m => m.UserName == user.UserName && m.Password == user.Password).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("AdminPage", "User");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}