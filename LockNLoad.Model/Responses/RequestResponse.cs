using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Responses
{
    public class RequestResponse
    {
        public int Id { get; set; }
        public int? ReviewId { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDateTime { get; set; }
        public int? RejectedBy { get; set; }
        public DateTime? RejectedDateTime { get; set; }
        public string? Description { get; set; }
    }
}
