using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Request
    {
        public Request()
        {
            Bills = new HashSet<Bill>();
            UserAppointments = new HashSet<UserAppointment>();
        }

        public int Id { get; set; }
        public int? ReviewId { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDateTime { get; set; }
        public int? RejectedBy { get; set; }
        public DateTime? RejectedDateTime { get; set; }
        public string? Description { get; set; }
        public DateTime? RecordDateTime { get; set; }

        public virtual Review? Review { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<UserAppointment> UserAppointments { get; set; }
    }
}
