//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using Newtonsoft.Json;
//using SwordLMS.Web.Models;
//using System.Linq.Expressions;

//namespace SwordLMS.Web.ViewComponents
//{

//    [ViewComponent(Name = "ContentComponent")]
//    public class CourseContentViewComponent : ViewComponent
//    {
//        private readonly SwordLmsContext _context;
//        //private readonly IWebHostEnvironment _hostingEnviroment;

//        public CourseContentViewComponent(SwordLmsContext context)
//        {
//            _context = context;
            

//        }

//        public IViewComponentResult InvokeAsync(CourseContent coursecontent)
//        {

//            var coursecontents = new CourseContent();


//            return View(coursecontents);

//        }

//    }
//}
//        public async Task<IActionResult> SaveContentComponent(IFormFile file, [FromForm] string data)
//        {
//            string filePath = string.Empty;
//            CourseContent coursecontents = null;

//            if (file != null && file.Length > 0 && data != null)
//            {
//                string fileName = Path.GetFileName(file.FileName);
//                string fileExtension = Path.GetExtension(fileName);
//                string newFileName = Guid.NewGuid().ToString() + fileExtension;
//                using (var stream = new FileStream(filePath, FileMode.Create))
//                {
//                    file.CopyTo(stream);
//                }
//            }
//            coursecontents = JsonConvert.DeserializeObject<CourseContent>(data);
//            if (coursecontents is not null)
//            {
//                coursecontents.ContentPath = filePath;
//                _context.CourseContents.Add(coursecontents);
//                _context.SaveChanges();

//            }
//            else
//            {
//                System.IO.File.Delete(filePath);
//                return null;
//            }
         
//            return null;
//        }
//    }
//}
    