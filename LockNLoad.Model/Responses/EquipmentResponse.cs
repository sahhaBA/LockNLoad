using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Responses
{
    public class EquipmentResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public int? Quantity { get; set; }
        public string? EquipmentImageUrl { get; set; }
        public double? PricePerUnit { get; set; }
        public double? AmmoPricePerUnit { get; set; }
    }
}
