using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using SwordLMS.Web.Models;
using System.Security.Claims;
using NUnit.Framework;
using System.Drawing;

namespace SwordLMS.Web.Controllers
{
    public class CourseController : Controller
    {


        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly SwordLmsContext _context;

        private readonly Course course;

        // private readonly CourseViewModel _courseViewModel;

        CourseViewModel courseViewModel = new CourseViewModel();

        public CourseController(SwordLmsContext context /*CourseViewModel courseViewModel*/, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            //_courseViewModel = courseViewModel;
        }

        //public JsonResult GetCourseSkills(int id)
        //{
        //    var courseskills = _context.Skills.Where(x => x.Id == id).OrderBy(x =>x.Name).ToList();
        //    return Json(courseskills);
        //}
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(User user, Course course)
        {

            ViewData["skills"] = new SelectList(_context.Skills.AsNoTracking().ToList(), "Id", "Name");

            ViewBag.userId = User.Claims.FirstOrDefault(c => c.Type == "userid")?.Value;
            //  ViewData["contenttype"] = new SelectList(_context.ContentTypes.ToList(), "Id", "Type");
            // ViewBag.contentType = new SelectList(_context.ContentTypes.ToList(), "Id", "Type");
            ViewData["contentType"] = new SelectList(_context.ContentTypes.AsNoTracking().ToList(), "Id", "Type");
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SaveCourseDetailsOne([FromBody] string courseData)
        {

            return new JsonResult(1);
        }

        public JsonResult SaveCourseDetailsTwo(String fromData)
        {
            var course = JsonConvert.DeserializeObject<Course>(fromData);
            var courseName = course.Name;
            var description = course.Description;
            var durationInMins = course.DurationInMins;
            var dateOfPublish = course.DateOfPublish;
            var displayImagePath = course.DisplayImagePath;
            var price = course.Price;

            return Json(new { success = true });

        }

        public async Task<IActionResult> SaveCourseContent(IFormFile file, [FromForm] string data)
        {
            string filePath = string.Empty;
            CourseContent coursecontents = null;
            try
            {
                if (file != null && file.Length > 0 && data != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string fileExtension = Path.GetExtension(fileName);
                    string newFileName = Guid.NewGuid().ToString() + fileExtension;
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

                }

                else
                {
                    System.IO.File.Delete(filePath);
                    return null;
                }
            }

            catch (Exception ex)
            {
                //if (coursecontents.Id == null)
                //{
                //    System.IO.File.Delete(filePath);
                //}
                return null;
            }
            return null;
        }



        public async Task<IActionResult> SaveCourse(IFormFile file, [FromForm] string data)
        {
            string filePath = string.Empty;
            Course course = null;
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

                    filePath = Path.Combine(_hostingEnvironment.WebRootPath, "CourseContents", newFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
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
                    return null;
                }
                // return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                if (course.Id == null)
                {
                    System.IO.File.Delete(filePath);
                }
                return null;
            }
        }


        public async Task<IActionResult> SaveSkills([FromQuery] string data)
        {
            var courses = JsonConvert.DeserializeObject<SkillsViewModel>(data);

            //CourseSkill courseSkills = null;

            List<CourseSkill> listskills = new List<CourseSkill>();

            foreach (var skillid in courses.SkillsId)
            {
                CourseSkill skill = new CourseSkill();

                skill.SkillsId = int.Parse(skillid);
                skill.CourseId = courses.CourseId;


                _context.CourseSkills.Add(skill);
                _context.SaveChanges();
            }


            return Ok();

            //return Json();

        }

        public async Task<IActionResult> SaveTopics([FromQuery] string data1)
        {


            var courseTopic = JsonConvert.DeserializeObject<CourseTopic>(data1);


            //CourseTopic courseTopic1 = new CourseTopic();



            _context.CourseTopics.Add(courseTopic);
            _context.SaveChanges();
            //return Ok();
            // return ok(courseTopic.Name , courseTopic.DurationInMins);
            ViewBag.CourseTopic = courseTopic.Id;
            return Ok(courseTopic);


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

        public IActionResult GetContentComponent()
        {
            return ViewComponent("ContentComponent");
        }

    }
}
