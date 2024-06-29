using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Requests
{
    public class ReviewInsertRequest
    {
        public int Grade { get; set; }
        public string? Description { get; set; }
    }
}
