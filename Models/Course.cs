using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int AuthorId { get; set; }

    public int DurationInMins { get; set; }

    public DateTime? DateOfPublish { get; set; }

    public double? Ratings { get; set; }

    public string DisplayImagePath { get; set; } = null!;

    public double Price { get; set; }

    public virtual CourseReview? CourseReview { get; set; }

    public virtual ICollection<CourseSkill> CourseSkills { get; } = new List<CourseSkill>();

    public virtual ICollection<CourseTopic> CourseTopics { get; } = new List<CourseTopic>();

    public virtual ICollection<UserCourse> UserCourses { get; } = new List<UserCourse>();
}
