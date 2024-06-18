using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Requests
{
    public class UserInsertRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int GenderId { get; set; }
        public int? Age { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime DateOfRegistration { get; set; } 

        [Compare("PasswordConfirmaton", ErrorMessage = "Passwords do not match.")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string PasswordConfirmaton { get; set; } = null!;

    }
}
