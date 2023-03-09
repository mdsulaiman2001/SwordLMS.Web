using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class CourseContent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TopicId { get; set; }

    public int ContentTypeId { get; set; }

    public int DurationInMins { get; set; }

    public string ContentPath { get; set; } = null!;

    public virtual ContentType ContentType { get; set; } = null!;

    public virtual CourseTopic Topic { get; set; } = null!;

    public virtual ICollection<UserContent> UserContents { get; } = new List<UserContent>();
}
