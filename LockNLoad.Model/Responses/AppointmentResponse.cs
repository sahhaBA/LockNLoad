using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Responses
{
    public class AppointmentResponse
    {
        public int Id { get; set; }
        public int TrainingGroundId { get; set; }
        public string TrainingGroundName { get; set; } = null!;
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? MaxParticipants { get; set; }
        public bool? IsBooked { get; set; }
        public string? Description { get; set; }
    }
}
