using Microsoft.Build.Framework;


using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SwordLMS.Web.Models;

public partial class CourseTopic
{
    public int Id { get; set; }

    
    public int CourseId { get; set; }

    [Required(ErrorMessage = "Name Filed Is Required")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Duration Filed Is Required")]
    public int DurationInMins { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<CourseContent> CourseContents { get; } = new List<CourseContent>();
}
