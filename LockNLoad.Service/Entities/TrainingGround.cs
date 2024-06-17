using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class TrainingGround
    {
        public TrainingGround()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? LocationImageUrl { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
