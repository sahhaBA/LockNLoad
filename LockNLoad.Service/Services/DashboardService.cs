using LockNLoad.Model.Responses;
using LockNLoad.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Service.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;
        private readonly IRequestService _requestService;
        private readonly IBillService _billService;

        public DashboardService(IUserService userService, IAppointmentService appointmentService, IRequestService requestService, IBillService billService)
        {
            _userService = userService;
            _appointmentService = appointmentService;
            _requestService = requestService;
            _billService = billService;
        }

        public async Task<DashboardResponse> GetDashboardDataAsync()
        {
            var totalRegisteredUsers = await _userService.GetTotalNumberOfUsers();
            var totalActiveAppointments = await _appointmentService.GetTotalActiveAppointments();
            var totalPendingRequests = await _requestService.GetTotalPendingRequests();
            var totalRevenue = await _billService.GetTotalRevenue();

            var currentMonthData = new CurrentMonthDto
            {
                TotalRevenue = await _billService.GetCurrentMonthRevenue() ?? 0,
                MostValuableUsers = await _userService.GetMostValuableUsersForCurrentMonth(),
                TotalNewRegisteredUsers = await _userService.GetTotalNumberOfRegisteredUsersForCurrentMonth(),
                TotalAppointments = await _appointmentService.GetTotalNumberOfAppointmentsForCurrentMonth()
            };

            var lastRequests = await _requestService.GetLatestRequests();

            var model = new DashboardResponse
            {
                TotalRegisteredUsers = totalRegisteredUsers,
                TotalActiveAppointments = totalActiveAppointments,
                TotalPendingRequests = totalPendingRequests,
                TotalRevenue = totalRevenue ?? 0,
                CurrentMonthData = currentMonthData,
                LastRequests = lastRequests
            };

            return model;
        }
    }
}
