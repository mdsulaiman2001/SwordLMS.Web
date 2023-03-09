using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SubCategory> SubCategories { get; } = new List<SubCategory>();
}
