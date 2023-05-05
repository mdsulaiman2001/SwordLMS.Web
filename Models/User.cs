using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwordLMS.Web.Models;

public partial class User 
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please Enter Your First Name"), MaxLength(150)]

    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please Enter Your Last Name"), MaxLength(150)]

    public string LastName { get; set; }= string.Empty;


    [Required(ErrorMessage = "Please Enter Your Email"), MaxLength(50)]
    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
    public string Email { get; set; } = null!;

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
    public string Password { get; set; } = null!;

    public int? State { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int? Country { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = new Role();

    public virtual ICollection<UserContent> UserContents { get; } = new List<UserContent>();

    public virtual UserCourse? UserCourse { get; set; }
}
