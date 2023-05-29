using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwordLMS.Web.Models;

public partial class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage="Category Name Is Required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Image is Required!")]
    [DataType(DataType.ImageUrl)] 
    public string Image { get; set; }   = string.Empty;


    public bool IsActive { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; } = new List<SubCategory>();
}
