using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class UserContent
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ContentId { get; set; }

    public bool IsCompleted { get; set; }

    public int? WatchedDuration { get; set; }

    public virtual CourseContent Content { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
