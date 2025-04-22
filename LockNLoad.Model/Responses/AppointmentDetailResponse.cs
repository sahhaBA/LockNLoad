using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Responses
{
    public class AppointmentDetailResponse
    {
        public int AppointmentId { get; set; }
        public int TrainingGroundId { get; set; }
        public string TrainingGroundName { get; set; }
        public string TrainingGroundLocation { get; set; }
        public string TrainingGroundLocationImageUrl { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndDate { get; set; }
        public int NumberOfParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public List<RequestDto> Requests { get; set; } = new List<RequestDto>();
    }
}
