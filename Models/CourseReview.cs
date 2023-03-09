using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class CourseReview
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int UserId { get; set; }

    public int AuthorId { get; set; }

    public int Rating { get; set; }

    public string Comments { get; set; } = null!;

    public virtual Course IdNavigation { get; set; } = null!;
}
