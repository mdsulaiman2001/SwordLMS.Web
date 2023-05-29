using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SwordLMS.Web.Models;

public partial class CourseContent
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Name Is Required")]
    public string Name { get; set; } = null!;


    public int TopicId { get; set; }

    public int ContentTypeId { get; set; }

    [Required(ErrorMessage="Duration In Mintues")]
    public int DurationInMins { get; set; }

    [Required(ErrorMessage="ContentPath Is Required")]
    public string ContentPath { get; set; } = null!;

    public virtual ContentType ContentType { get; set; } = null!;

    public virtual CourseTopic Topic { get; set; } = null!;

    public virtual ICollection<UserContent> UserContents { get; } = new List<UserContent>();
}
