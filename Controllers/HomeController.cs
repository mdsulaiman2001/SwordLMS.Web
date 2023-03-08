using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace SwordLMS.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
       // private readonly ClaimsPrincipal user;

        //public readonly IHttpContextAccessor _iHttpContextAccessor;
        //public readonly IActionContextAccessor _actionContextAccessor;
      //  public HomeController(IHttpContextAccessor httpContextAccessor, IActionContextAccessor actionContextAccessor)
        public HomeController()
        {
          
        }
        public IActionResult Index()
        {
            //ViewBag.FullName = _iHttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;
            //ViewBag.UserName = _iHttpContextAccessor.HttpContext.User.Identity.Name;
            //ViewBag.Role = _iHttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            ViewBag.Title = "Home";
            ViewBag.Welcome = "Welcome, " + User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;
            return View();
        }
    }
}
