using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Requests
{
    public class EquipmentInsertRequest
    {
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public string EquipmentImageUrl { get; set; } = null!;
        public double PricePerUnit { get; set; }
        public double AmmoPricePerUnit { get; set; }
    }
}
