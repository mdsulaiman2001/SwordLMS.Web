using Microsoft.AspNetCore.Mvc;

namespace SwordLMS.Web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentPage()
        {
            return View();
        }
    }
}
