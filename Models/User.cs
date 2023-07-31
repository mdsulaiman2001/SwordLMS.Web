﻿using System;
using System.Collections.Generic;

namespace SwordLMS.Web.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public int? City { get; set; }

    public int Pincode { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? State { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int? Country { get; set; }

    public int RoleId { get; set; }

    public bool IsActive { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<UserContent> UserContents { get; } = new List<UserContent>();

    public virtual UserCourse? UserCourse { get; set; }
}
