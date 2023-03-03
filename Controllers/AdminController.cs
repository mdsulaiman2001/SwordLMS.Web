using Microsoft.AspNetCore.Mvc;

namespace SwordLMS.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminPage()
        {
            return View();
        }
    }
}
