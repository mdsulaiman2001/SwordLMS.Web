
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace SwordLMS.Web.Models;

public partial class User  
{
    public int Id { get; set; }

    //[Required(ErrorMessage = "Please Enter Your First Name"), MaxLength(150)]

    [Required(ErrorMessage = "you must enter firstname")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "you must enter lastname"), MaxLength(150)]

    public string LastName { get; set; }= string.Empty;

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Please Enter Your Email"), MaxLength(50)]
    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
    public string Email { get; set; } = null!;

  
    [Required(ErrorMessage = "Please enter the date of birth")]
   // [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{yyyy-MM-dd : 00:00:00.000}", ApplyFormatInEditMode = true)]

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public int? City { get; set; } = null!;

    [Required(ErrorMessage = "Pincode Is Required!")]
    [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{2})$",
                  ErrorMessage = "Enter the valid pincode.")]
    public int Pincode { get; set; }

    [Required(ErrorMessage = "please enter username")]
    [Display(Name = "User name")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage="please enter password")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]

    //[StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
    //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
    public string Password { get; set; } = null!;

    public int? State { get; set; }

    
    [Required(ErrorMessage = "Phone Number Required!")]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
    public string PhoneNumber { get; set; } = string.Empty;

    public int? Country { get; set; } = null!;

    public int RoleId { get; set; }

    public bool IsActive { get; set; }

    public virtual Role Role { get; set; } 

    public virtual ICollection<UserContent> UserContents { get; } = new List<UserContent>();

    public virtual UserCourse? UserCourse { get; set; }
}
