using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SwordLMS.Web.Models;

public partial class Course
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public int AuthorId { get; set; }
    [Required]
    public int DurationInMins { get; set; }
    [Required]
    public DateTime? DateOfPublish { get; set; }

    public double? Ratings { get; set; }

    [DisplayName("Upload File")]
    public string DisplayImagePath { get; set; } = string.Empty;
    [Required]
    public double Price { get; set; }

    public bool IsPublished { get; set; }

    public virtual CourseReview? CourseReview { get; set; }

    public virtual CourseSkill? CourseSkill { get; set; }

    public virtual ICollection<CourseTopic> CourseTopics { get; } = new List<CourseTopic>();

    public virtual ICollection<UserCourse> UserCourses { get; } = new List<UserCourse>();
}

