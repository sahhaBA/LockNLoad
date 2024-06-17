using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Category
    {
        public Category()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
