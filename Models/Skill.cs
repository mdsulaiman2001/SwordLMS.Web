using Microsoft.Build.Framework;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SwordLMS.Web.Models;

public partial class Skill
{
    public int Id { get; set; }

    [Required(ErrorMessage="Name Is Required ")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Version Is Required")]
    public string? Version { get; set; }

    [Required(ErrorMessage ="Description Is Required")]
    public string? Description { get; set; }

    public int SubCategoryId { get; set; }

    public virtual SubCategory SubCategory { get; set; } = null!;
}
