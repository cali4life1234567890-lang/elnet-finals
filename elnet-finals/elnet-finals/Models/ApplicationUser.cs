using System;
using Microsoft.AspNetCore.Identity;

namespace elnet_finals.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public Gender Gender { get; set; }
    }
}