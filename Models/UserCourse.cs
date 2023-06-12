using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwordLMS.Web.Models;

public partial class UserCourse
{
    [Key]
    public int UserId { get; set; }

    public int CourseId { get; set; }

    public DateTime? DateOfEnroll { get; set; }

    public int? WatchedDuration { get; set; }

    public bool? IsCompleted { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
