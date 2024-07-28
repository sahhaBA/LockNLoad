using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Constants
{
    public static class Enumerations
    {
        public enum RequestStatus
        {
            Approved,
            Pending,
            Rejected
        }

        public enum AppointmentStatus
        {
            Opened,
            Closed
        }

        public enum RequestType { 
            Applied,
            Booked
        }
    }
}
