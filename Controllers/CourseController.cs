using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using SwordLMS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using SwordLMS.Web.Repository;

namespace SwordLMS.Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {

       
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly SwordLmstwoContext _context;
        public IUserRepository _userRepository;
        CourseViewModel courseViewModel = new CourseViewModel();

 
        public CourseController(SwordLmstwoContext context, IWebHostEnvironment hostingEnvironment, IUserRepository userRepository)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _userRepository = userRepository;
        }

       public IActionResult StudentHome()
        {
            var categoriesList = _context.Categories.ToListAsync();
            return View(categoriesList);
        }

        public IActionResult Index()
        {
            return View();
        }
     
        public IActionResult Create()
        {


            ViewData["skills"] = new SelectList(_context.Skills.AsNoTracking().ToList(), "Id", "Name");
            ViewBag.userId = User.Claims.FirstOrDefault(c => c.Type == "userid")?.Value;
            //  ViewData["contenttype"] = new SelectList(_context.ContentTypes.ToList(), "Id", "Type");
            // ViewBag.contentType = new SelectList(_context.ContentTypes.ToList(), "Id", "Type");
            ViewData["contentType"] = new SelectList(_context.ContentTypes.AsNoTracking().ToList(), "Id", "Type");
            return View();
        }

        [HttpPost]
        public JsonResult SaveCourseDetailsOne([FromBody] string courseData)
        {

            return new JsonResult(1);
        }


        [Authorize(Roles = "Student")]
        public IActionResult StudentPage()
        {
            //var categoryList = _userRepository.GetAll<Course>();
            //return View(categoryList);
            

            //var courses = _context.Courses.Where(c=>c.IsPublished).ToList();
            
            return View(/*courses*/);
        }
      
        public IActionResult SaveCourseContent(IFormFile file, [FromForm] string data)
        {
            string filePath = string.Empty;
            CourseContent  coursecontents = null;
            try
            {
                if (file != null && file.Length > 0 && data != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string fileExtension = Path.GetExtension(fileName);
                    string newFileName = Guid.NewGuid().ToString() + fileExtension;
                    filePath = Path.Combine(_hostingEnvironment.WebRootPath, "CourseContents", newFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                }
                coursecontents = JsonConvert.DeserializeObject<CourseContent>(data);
                if (coursecontents is not null)
                {
                    coursecontents.ContentPath = filePath;
                    _context.CourseContents.Add(coursecontents);
                    _context.SaveChanges();
                    return Ok(coursecontents);

                }

                else
                {
                    System.IO.File.Delete(filePath);
                    return null;
                }
            }

            catch (Exception ex)
            {
                
                if (coursecontents.Id == null)
                {
                    System.IO.File.Delete(filePath);
                }
                return null;
            }
        }

        public IActionResult SaveCourse(IFormFile file, [FromForm] string data)
        {
            string filePath = string.Empty;
            string fileRoot = string.Empty;
            Course course = new Course();

            try
            {
                // var dateTime = DateTime.Now.ToShortDateString();
                // course.DateOfPublish = Convert.ToDateTime(dateTime);
                // course.DisplayImagePath = "";
                if (file != null && file.Length > 0 && data != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string fileExtension = Path.GetExtension(fileName);

                    string newFileName = Guid.NewGuid().ToString() + fileExtension;

                    filePath = newFileName;

                    fileRoot = Path.Combine(_hostingEnvironment.WebRootPath, "CourseContents", newFileName);

                    using (var stream = new FileStream(fileRoot, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                }
                course = JsonConvert.DeserializeObject<Course>(data);
                if (course is not null)
                {
                    course.DisplayImagePath = filePath;
                    _context.Courses.Add(course);
                    _context.SaveChanges();
                    return Json(course.Id);
                }
                else
                {
                    System.IO.File.Delete(filePath);
                    return Ok("deleted successfully");
                }
                // return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                if (course.Id == null)
                {
                    // System.IO.File.Delete(filePath);
                }
                return null;
            }
        }

        public IActionResult SaveSkills([FromQuery] string data)
        {
            
            _userRepository.SaveSkill(data);
            return Ok();

        }

        public IActionResult SaveTopics([FromQuery] string data1)
        {


            var courseTopic = JsonConvert.DeserializeObject<CourseTopic>(data1);

            if (courseTopic == null)
            {
                return BadRequest();
            }
            //CourseTopic courseTopic1 = new CourseTopic();

            _context.CourseTopics.Add(courseTopic);
          _context.SaveChanges();
           
            ViewBag.CourseTopic = courseTopic.Id;
            return Ok(courseTopic);
        }

       public IActionResult SaveContent(CourseContent courseContent )
        {
            if (ModelState.IsValid)
            {
                _context.CourseContents.Add(courseContent);
                _context.SaveChangesAsync();
               
               
                return RedirectToAction("Create");

            }
            return View();
        }
      
        public IActionResult GetContentComponent()
        {
            return ViewComponent("ContentComponent");
        }

    }
}
