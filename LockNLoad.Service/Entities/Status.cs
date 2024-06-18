using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Status
    {
        public Status()
        {
            Bugs = new HashSet<Bug>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Bug> Bugs { get; set; }
    }
}
