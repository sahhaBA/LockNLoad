using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Responses
{
    public class UserAppointmentEquipmentResponse
    {
        public int Id { get; set; }
        public int? UserAppointmentId { get; set; }
        public int? EquipmentId { get; set; }
        public int? Quantity { get; set; }
        public int? AmmoQuantity { get; set; }
    }
}
