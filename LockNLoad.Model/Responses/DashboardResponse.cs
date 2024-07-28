using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LockNLoad.Model.Constants.Enumerations;

namespace LockNLoad.Model.Responses
{
    public class DashboardResponse
    {
        public int TotalRegisteredUsers { get; set; }
        public int TotalActiveAppointments { get; set; }
        public int TotalPendingRequests { get; set; }
        public double TotalRevenue { get; set; }

        public CurrentMonthDto CurrentMonthData { get; set; } = new CurrentMonthDto();
        public List<RequestDto> LastRequests { get; set; } = new List<RequestDto>();
    }

    public class RequestDto
    {
        public RequestType Type { get; set; }
        public UserBasicDto User { get; set; } = new UserBasicDto();
        public double Credit { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
    }

    public class CurrentMonthDto
    {
        public double TotalRevenue { get; set; }
        public List<UserBasicDto> MostValuableUsers { get; set; } = new List<UserBasicDto>();
        public int TotalNewRegisteredUsers { get; set; }
        public int TotalAppointments { get; set; }
    }

    public class UserBasicDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => string.Join(" ", FirstName, LastName);
        public string UserName { get; set; } = null!;
        public string ProfileImageUrl { get; set; } = null!;
        public double Credit { get; set; }
    }
}
