using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SwordLMS.Web.Models
{
    public class ResetPassword
    {
        [Required]
        public String Email { get; set; } = string.Empty;

        [Required]
        public string Token { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        public string Password { get; set; }=string.Empty;

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public bool IsSuccess { get; set; }
    }
}
