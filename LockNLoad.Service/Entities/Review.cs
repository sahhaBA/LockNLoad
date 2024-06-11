using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Review
    {
        public Review()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public int? Grade { get; set; }
        public string? Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
