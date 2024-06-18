using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Bug
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? DateTime { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public string? Description { get; set; }

        public virtual Status? Status { get; set; }
        public virtual User? User { get; set; }
    }
}
