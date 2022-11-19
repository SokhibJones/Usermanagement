using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserManagementTask.Areas.Identity.Data;

public enum Status
{
    Active,
    Blocked
}

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public DateTimeOffset LoginTime { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset RegistrationTime { get; set; } = DateTimeOffset.Now;
    public Status Status { get; set; } = Status.Active;
}

