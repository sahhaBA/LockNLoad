using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Requests
{
    public class RequestUpdateRequest
    {
        public int ReviewId { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDateTime { get; set; }
        public int? RejectedBy { get; set; }
        public DateTime? RejectedDateTime { get; set; }
        public string? Description { get; set; }
    }
}
