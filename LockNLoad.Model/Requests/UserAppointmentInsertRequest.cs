using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Requests
{
    public class UserAppointmentInsertRequest
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int AppointmentId { get; set; }
    }
}
