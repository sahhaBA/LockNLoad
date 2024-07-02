using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Constants
{
    public static class Enumerations
    {
        public enum RequestStatuses
        {
            Approved,
            Pending,
            Rejected
        }

        public enum RequestTypes { 
            Applied,
            Booked
        }
    }
}
