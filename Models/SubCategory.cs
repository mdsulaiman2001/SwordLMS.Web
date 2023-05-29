using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SwordLMS.Web.Models;

public partial class SubCategory
{
    public int Id { get; set; }

    [Required(ErrorMessage = "subcategory name is Rqquired")]
    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}
