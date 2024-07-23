using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Gender
    {
        public Gender()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
