using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework.Constraints;

using SwordLMS.Web.Models;
using System.Security.Claims;
using System.Web.Helpers;

namespace SwordLMS.Web.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly SwordLmsContext _context;

        public AuthorController(SwordLmsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuthorList()
        {
            var users = _context.Users.Where(u => u.RoleId == 2).ToList();
            return View(users);
        }


        public IActionResult ActivateAuthor(int Userid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == Userid);
            if (user == null)          
                return NotFound();
            
            else
             user.IsActive = true;
            _context.SaveChanges();
            return RedirectToAction("AuthorList");

        }

        public IActionResult DeactivateAuthor(int Userid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == Userid);
            if (user == null)          
                return NotFound();
            
            user.IsActive = false;
            _context.SaveChanges();
            return RedirectToAction("AuthorList");
        }

      public IActionResult AuthorCourses()
        {
          var user=  User.Claims.FirstOrDefault(c => c.Type == "userid")?.Value;           
            var userid = Convert.ToInt32(user);
            var course = _context.Courses.Where(u=> u.AuthorId == userid).ToList();                 
            return View(course);
        }


        public IActionResult CourseActive(int CourseId)
        {
            var course = _context.Courses.FirstOrDefault( u =>u.Id== CourseId);
            if (course == null)
                return NotFound();
            else
            course.IsPublished = true;
            _context.SaveChanges();
            return RedirectToAction("AuthorCourses");
        }

        public IActionResult CourseDeactive(int CourseId)
        {
            var course = _context.Courses.FirstOrDefault(u => u.Id == CourseId);
            if(course == null)
                return NotFound();
            else
            course.IsPublished = false;
            _context.SaveChanges();
            return RedirectToAction("AuthorCourses");

        }


    }
}
