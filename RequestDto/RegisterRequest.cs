using SwordLMS.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace SwordLMS.Web.Request
{
    public class RegisterRequest
    {
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter Your Last Name"), MaxLength(150)]

        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please Enter Your Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                                ErrorMessage = "Email is not valid")]
        public string Email { get; set; } = string.Empty !;

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; } = null!;

        public int? City { get; set; } = null!;

        public int Pincode { get; set; }

        [Required(ErrorMessage = "please enter username")]
        [Display(Name = "User name")]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } 

        public int? State { get; set; } = null!;

        public string PhoneNumber { get; set; }

        public int? Country { get; set; } = null!;

        public int RoleId { get; set; }

       






    }
}
