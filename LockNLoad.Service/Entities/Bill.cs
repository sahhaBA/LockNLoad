using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Bill
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RequestId { get; set; }
        public int? Amount { get; set; }
        public bool? IsPaid { get; set; }
        public DateTime DateTime { get; set; }

        public virtual User? User { get; set; }
        public virtual Request? Request { get; set; }
    }
}
