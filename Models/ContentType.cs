using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class ContentType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<CourseContent> CourseContents { get; } = new List<CourseContent>();
}
