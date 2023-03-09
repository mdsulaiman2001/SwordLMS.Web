using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Version { get; set; }

    public string? Description { get; set; }

    public int SubCategoryId { get; set; }

    public virtual SubCategory SubCategory { get; set; } = null!;
}
