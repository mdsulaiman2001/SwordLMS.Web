using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class CourseTopic
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public int DurationInMins { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<CourseContent> CourseContents { get; } = new List<CourseContent>();
}
