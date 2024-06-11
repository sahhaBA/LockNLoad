using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class UserAppointmentEquipment
    {
        public int Id { get; set; }
        public int? UserAppointmentId { get; set; }
        public int? EquipmentId { get; set; }
        public int? Quantity { get; set; }
        public int? AmmoQuantity { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Equipment? Equipment { get; set; }
        public virtual UserAppointment? UserAppointment { get; set; }
    }
}
