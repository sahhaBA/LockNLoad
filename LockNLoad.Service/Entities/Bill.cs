using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Bill
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public int? Amount { get; set; }
        public bool? IsPaid { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Request? Request { get; set; }
    }
}
