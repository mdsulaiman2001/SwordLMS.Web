using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SwordLMS.Web.Models;
using SwordLMS.Web.Repository;
using System.Security.Claims;

namespace SwordLMS.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SwordLmsContext _context;
        private readonly UserRepository _userRepository;
        // private readonly ClaimsPrincipal user;

        //public readonly IHttpContextAccessor _iHttpContextAccessor;
        //public readonly IActionContextAccessor _actionContextAccessor;
        //  public HomeController(IHttpContextAccessor httpContextAccessor, IActionContextAccessor actionContextAccessor)
        public HomeController(SwordLmsContext context, UserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        //[Authorize(Roles = "Admin")]
        //public IActionResult AdminIndex()
        //{
        //    ViewBag.Title = "Home";
        //    ViewBag.Welcome = "Welcome, " + User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;
        //    return View();
        //}

        //[Authorize(Roles = "Author")]
        //public IActionResult AuthorIndex()
        //{
        //    ViewBag.Title = "Home";
        //    ViewBag.Welcome = "Welcome, " + User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;
        //    return View();
        //}
        //[Authorize(Roles = "Student")]
        //public IActionResult  StudentIndex()
        //{
        //    ViewBag.Title = "Home";
        //    ViewBag.Welcome = "Welcome, " + User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;



        //            var category = _context.Categories.ToList();
        //           return View(category);  

        //}





        public IActionResult Index()
        {
            //ViewBag.FullName = _iHttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;
            //ViewBag.UserName = _iHttpContextAccessor.HttpContext.User.Identity.Name;
            //ViewBag.Role = _iHttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            ViewBag.Title = "Home";
            ViewBag.Welcome = "Welcome, " + User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;


            if (User?.Identity?.IsAuthenticated == true)
            {
                if (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "Student")
                {
                    var category = _context.Categories.Where(c => c.IsActive).ToList();
                    return View(category);
                }

            }
            return View();


        }


        //public IActionResult SubCategory(int categoryId)
        //{         
        //        var subcategories = _context.SubCategories.Where(u => u.CategoryId == categoryId).ToList();

          
        //        return View(subcategories);          
         
        //}

        //public IActionResult Skills(int categoryId)
        //{
        //    var skillList = _context.Skills.Where(u => u.SubCategoryId == skillsId).ToList();
        //    return View(skillList);
        //}

        public IActionResult Category(int categoryId,  int skillsId)
        {

            var subcategory = _userRepository.GetSubCategory(categoryId);

            var Skills = _userRepository.GetSkills(skillsId);

            var viewModel = new CategoryModelView
            {
                subCategories = subcategory,
                skills = Skills
            };


            return View(viewModel);

        }

    }
}
