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
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
