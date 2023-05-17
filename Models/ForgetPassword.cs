
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SwordLMS.Web.Models
{
    public class ForgetPassword
    {
        [Required(ErrorMessage = "please enter username")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;


        public string Token { get; set; }  =string.Empty;
        public bool EmailSent { get; set; }


    }
}
