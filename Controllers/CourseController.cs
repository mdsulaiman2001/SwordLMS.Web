using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwordLMS.Web.Models;
using System.Security.Claims;

namespace SwordLMS.Web.Controllers
{
    public class CourseController : Controller
    {

     

        private readonly SwordLmsContext _context;

        // private readonly CourseViewModel _courseViewModel;

        CourseViewModel courseViewModel = new CourseViewModel();





        public CourseController(SwordLmsContext context /*CourseViewModel courseViewModel*/)
        {
            _context = context;
            //_courseViewModel = courseViewModel;
        }

        //public JsonResult GetCourseSkills(int id)
        //{
        //    var courseskills = _context.CourseSkills.Where(x => x.SkillsId==id ).ToList();
        //    return new JsonResult(courseskills);
        //}

      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(User user, Course course)
        {

           // string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            ViewBag.userId = User.Claims.FirstOrDefault(c => c.Type == "userid")?.Value;

            


            return View();
        }

        [HttpPost]
        //public JsonResult SaveCourseDetailsOne([FromBody] string courseData)
        //{
        //    return new JsonResult(1);
        //}

        //public JsonResult SaveCourseDetailsTwo(String fromData)
        //{
        //    var course = JsonConvert.DeserializeObject<Course>(fromData);
        //    var courseName = course.Name;
        //    var description = course.Description;
        //    var durationInMins = course.DurationInMins;
        //    var dateOfPublish = course.DateOfPublish;
        //    var displayImagePath = course.DisplayImagePath;
        //    var price= course.Price;


        //    return Json(new { success = true });

        //}
        public async Task<IActionResult> SaveCourse(Course course)
        {
            var dateTime = DateTime.Now.ToShortDateString();
            course.DateOfPublish = Convert.ToDateTime(dateTime);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create");

        }

        public async Task<IActionResult> SaveContent(CourseContent courseContent)
        {
            if (ModelState.IsValid)
            {
                _context.CourseContents.Add(courseContent);
                await _context.SaveChangesAsync();

                return RedirectToAction("Create");

            }
            return View();
        }

        public async Task<IActionResult> SaveTopics(CourseTopic courseTopic)
        {
            if (ModelState.IsValid)
            {
                _context.CourseTopics.Add(courseTopic);
                await _context.SaveChangesAsync();

                return RedirectToAction("Create");
            }
            return View();
        }
        public async Task<IActionResult> SaveSkills(CourseSkill courseSkill)
        {
            if (ModelState.IsValid)
            {
                _context.CourseSkills.Add(courseSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            return View();

        }
    }
}
