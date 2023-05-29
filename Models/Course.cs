using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SwordLMS.Web.Models;

public partial class Course
{
    public int Id { get; set; }


    [Required (ErrorMessage = "Name Required!")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description Required!")]
    public string Description { get; set; } = string.Empty;

    public int AuthorId { get; set; }

    [Required(ErrorMessage = "Duration Required!")]
    public int DurationInMins { get; set; }

    [Required(ErrorMessage = "Dateofpublish Required!")]
    public DateTime? DateOfPublish { get; set; }

    public double? Ratings { get; set; }

    //[DisplayName("Upload File")]
    [Required(ErrorMessage = "Image is Required!")]
    public string DisplayImagePath { get; set; } = string.Empty;

    [Required(ErrorMessage = "Price Required!")]
    public double Price { get; set; }

    public bool IsPublished { get; set; }

    public virtual CourseReview? CourseReview { get; set; }

    public virtual CourseSkill? CourseSkill { get; set; }

    public virtual ICollection<CourseTopic> CourseTopics { get; } = new List<CourseTopic>();

    public virtual ICollection<UserCourse> UserCourses { get; } = new List<UserCourse>();
}

