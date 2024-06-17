﻿using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
