using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SwordLMS.Web.Models
{
    public class ResetPassword
    {
        [Required(ErrorMessage = "please enter Email address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                              ErrorMessage = "Email is not valid")]
        public String Email { get; set; } = string.Empty;

        [Required]
        public string Token { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "please enter password")]
     
        public string Password { get; set; }=string.Empty;

        [DataType(DataType.Password)]
        [Compare("Password")]

        public string ConfirmPassword { get; set; } = string.Empty;

        public bool IsSuccess { get; set; }
    }
}
