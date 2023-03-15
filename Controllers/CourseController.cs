﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SwordLMS.Web.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SwordLMS.Web.Controllers
{
    public class CourseController : Controller
    {

        private readonly SwordLmsContext _context;

        // private readonly CourseViewModel _courseViewModel;

        CourseViewModel courseViewModel= new CourseViewModel();
       
       



        public CourseController(SwordLmsContext context /*CourseViewModel courseViewModel*/)
        {
            _context = context;
            //_courseViewModel = courseViewModel;
        }

        //public JsonResult GetCourseSkills(int id)
        //{
        //    var courseskills = _context.CourseSkills.Where(x => x.SkillsId==id ).ToList();
        //    return new JsonResult(courseskills );

        //}
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(User user , Course course)
        {
           var authorId= user.Id;
            authorId = course.AuthorId;

            return View();
        }

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
            if(ModelState.IsValid)
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