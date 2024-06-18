using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Responses
{
    public partial class UserResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int? Age { get; set; }
        public string? ProfileImageUrl { get; set; }
        public DateTime? DateOfRegistration { get; set; }

        public virtual ICollection<UserRoleResponse> UserRoles { get; set; } = new List<UserRoleResponse>();
    }
}
