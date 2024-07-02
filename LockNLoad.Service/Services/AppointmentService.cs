using AutoMapper;
using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Model.SearchObjects;
using LockNLoad.Service.Contexts;
using LockNLoad.Service.Entities;
using LockNLoad.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Service.Services
{

    public class AppointmentService : BaseCRUDService<AppointmentResponse, Appointment, AppointmentSearchObject, AppointmentInsertRequest, AppointmentUpdateRequest>, IAppointmentService
    {
        public AppointmentService(LockNLoadContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<int> GetTotalActiveAppointments()
        {
            return await _context.Appointments.Where(x => x.StartDateTime <= DateTime.Now && x.EndDateTime >= DateTime.Now).CountAsync();
        }

        public async Task<int> GetTotalNumberOfAppointmentsForCurrentMonth()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            return await _context.Appointments.Where(x => x.StartDateTime.Value.Year == currentYear && x.StartDateTime.Value.Month == currentMonth).CountAsync();
        }
    }
}
