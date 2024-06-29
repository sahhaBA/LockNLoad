using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Requests
{
    public class BillUpdateRequest
    {
        public int RequestId { get; set; }
        public int Amount { get; set; }
        public bool IsPaid { get; set; }
    }
}
