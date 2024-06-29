using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Responses
{
    public class DashboardResponse
    {
        public int TotalUsers { get; set; }
        public int ActiveAppointments { get; set; }
        public int PendingRequests { get; set; }
        public double TotalRevenue { get; set; }
        public double CurrentMonthRevenue { get; set; }
        public List<UserModel> TopUsers { get; set; }
        public List<UserModel> NewUsers { get; set; }
        public List<AppointmentModel> Appointments { get; set; }
    }
}
