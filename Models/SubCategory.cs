using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class SubCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}
