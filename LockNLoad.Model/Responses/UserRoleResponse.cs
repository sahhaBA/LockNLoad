﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Responses
{
    public class UserRoleResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
    }
}
