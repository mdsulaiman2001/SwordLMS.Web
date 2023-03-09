using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class FeedBack
{
    public int Id { get; set; }

    public double Rating { get; set; }

    public string FeedBack1 { get; set; } = null!;

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
