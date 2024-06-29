using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Requests
{
    public class AppointmentUpdateRequest
    {
        public int TrainingGroundId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int MaxParticipants { get; set; }
        public bool IsBooked { get; set; }
        public string? Description { get; set; }
    }
}
