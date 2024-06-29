using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Responses
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public int? Grade { get; set; }
        public string? Description { get; set; }
    }
}
