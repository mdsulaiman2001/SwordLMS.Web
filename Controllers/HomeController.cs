using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using SwordLMS.Web.Models;
using SwordLMS.Web.Services;
using System.Security.Claims;



namespace SwordLMS.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SwordLmsContext _context;







        public HomeController(SwordLmsContext context)
        {
            _context = context;



        }

        public IActionResult Index()
        {


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


        public List<SubCategory> GetSubCategory(int categoryId)
        {
            var subcategory = _context.SubCategories.Where(u => u.CategoryId == categoryId).ToList();
            return subcategory;

        }

        public IActionResult SubCategory(int categoryId)
        {
            var subcategory = GetSubCategory(categoryId);
            return View(subcategory);
        }

        [HttpGet]
       // public List<Skill> GetSkill(int skillId)
        //{

        //    var skill =_context.Skills.Where(u => u.SubCategoryId == skillId).ToList();
        //    return  View (skill);

        //}

        [HttpGet]        
        public IActionResult skill(int skillId)
        {
            var skill = _context.Skills.Where(u => u.SubCategoryId == skillId).ToList();
      
            
            return View(skill);

        

        }

        //public IActionResult SkillsPartialView(int skillsId)
        //{
        //    var skill = GetSkill(skillsId);
        //    return PartialView("_SkillsPartialView" ,skill);
        //}

    }
    }

