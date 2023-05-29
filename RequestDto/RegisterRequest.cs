using Microsoft.EntityFrameworkCore;
using SwordLMS.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace SwordLMS.Web.Request
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Please Firsr Your Last Name"), MaxLength(150)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter Your Last Name"), MaxLength(150)]

        public string LastName { get; set; } = string.Empty;


        [EmailAddress]
       
        [Required(ErrorMessage = "Please Enter Your Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                                ErrorMessage = "Email is not valid")]



       
        public string Email { get; set; } = string.Empty !;


        [Required(ErrorMessage = "Please enter the date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; } = null!;

        public int? City { get; set; } = null!;

        public int Pincode { get; set; }

        [Required(ErrorMessage = "please enter username")]
        [Display(Name = "User name")]
        public string UserName { get; set; } = null!;

        [Required (ErrorMessage = "Please Enter Your Password")] 
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        public int? State { get; set; } = null!;

        public string PhoneNumber { get; set; } = string.Empty;

        public int? Country { get; set; } = null!;

        public int RoleId { get; set; }

       






    }
}
