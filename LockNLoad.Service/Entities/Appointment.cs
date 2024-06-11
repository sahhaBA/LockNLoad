using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Appointment
    {
        public Appointment()
        {
            UserAppointments = new HashSet<UserAppointment>();
        }

        public int Id { get; set; }
        public int? TrainingGroundId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? MaxParticipants { get; set; }
        public bool? IsBooked { get; set; }
        public string? Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual TrainingGround? TrainingGround { get; set; }
        public virtual ICollection<UserAppointment> UserAppointments { get; set; }
    }
}
