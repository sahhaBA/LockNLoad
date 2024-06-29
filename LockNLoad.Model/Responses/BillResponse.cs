using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Responses
{
    public class BillResponse
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public int? Amount { get; set; }
        public bool? IsPaid { get; set; }
    }
}
