using Microsoft.AspNetCore.Mvc;
using SwordLMS.Web.Models;

namespace SwordLMS.Web.ViewComponents
{

    [ViewComponent(Name ="MyComponent")]
    public class CourseContentViewComponent : ViewComponent
    {
        private readonly SwordLmsContext _context;

       public CourseContentViewComponent (SwordLmsContext context)
        {
                _context= context;
      
        } 

        public async Task <IViewComponentResult> InvokeAsync(CourseContent coursecontent)
        {
          
            var coursecontents = new CourseContent();


            return View(coursecontents);
     
        }

        //public async Task <IActionResult> SaveContentComponent(CourseContent courseContent)
        //{
        //    _context.CourseContents.Add(courseContent);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("");
        //}
    }
}
    