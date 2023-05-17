using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SwordLMS.Web.RequestDto
{
    public class CourseRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int DurationInMins { get; set; }

        [Required]
        public DateTime? DateOfPublish { get; set; }

        [Required]
        public string DisplayImagePath { get; set; } = string.Empty;

        public double Price { get; set; }
    }
}
