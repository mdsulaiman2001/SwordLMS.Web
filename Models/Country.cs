using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<State> States { get; } = new List<State>();
}
