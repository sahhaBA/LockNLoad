using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class Equipment
    {
        public Equipment()
        {
            UserAppointmentEquipments = new HashSet<UserAppointmentEquipment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public int? Quantity { get; set; }
        public string? EquipmentImageUrl { get; set; }
        public double? PricePerUnit { get; set; }
        public double? AmmoPricePerUnit { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<UserAppointmentEquipment> UserAppointmentEquipments { get; set; }
    }
}
