using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LockNLoad.Model.Constants.Enumerations;

namespace LockNLoad.Model.SearchObjects
{
    public class AppointmentSearchObject : BaseSearchObject
    {
        public int? TrainingGroundId { get; set; }
        public AppointmentStatus? Status { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
