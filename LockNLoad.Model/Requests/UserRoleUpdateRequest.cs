using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Requests
{
    public class UserRoleUpdateRequest
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
