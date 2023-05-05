using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SwordLMS.Web.Models
{
    public class ForgetPasswordModelView
    {
        [Required(ErrorMessage = "please enter username")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
