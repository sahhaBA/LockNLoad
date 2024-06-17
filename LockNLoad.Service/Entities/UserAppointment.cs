using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class UserAppointment
    {
        public UserAppointment()
        {
            UserAppointmentEquipments = new HashSet<UserAppointmentEquipment>();
        }

        public int Id { get; set; }
        public int? RequestId { get; set; }
        public int? UserId { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointment? Appointment { get; set; }
        public virtual Request? Request { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<UserAppointmentEquipment> UserAppointmentEquipments { get; set; }
    }
}
