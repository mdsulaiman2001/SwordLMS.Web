using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int StateId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual State State { get; set; } = null!;
}
