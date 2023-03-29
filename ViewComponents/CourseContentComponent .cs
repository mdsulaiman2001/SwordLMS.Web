using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SwordLMS.Web.Models;

namespace SwordLMS.Web.ViewComponents
{

    [ViewComponent(Name = "ContentComponent")]
    public class CourseContentViewComponent : ViewComponent
    {
        private readonly SwordLmsContext _context;
        private readonly IWebHostEnvironment _hostingEnviroment;

       public CourseContentViewComponent (SwordLmsContext context)
        {
                _context= context;
      
        } 

        public async Task <IViewComponentResult> InvokeAsync(CourseContent coursecontent)
        {
          
            var coursecontents = new CourseContent();


            return View(coursecontents);
     
        }

        public async Task<IActionResult> SaveContentComponent(IFormFile file, [FromForm] string data)
        {
            //_context.CourseContents.Add(courseContent);
            await _context.SaveChangesAsync();
            return (IActionResult)View();
        }
    }
}
    