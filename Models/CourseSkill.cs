using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class CourseSkill
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int SkillsId { get; set; }

    public virtual Course Course { get; set; } = null!;
}
