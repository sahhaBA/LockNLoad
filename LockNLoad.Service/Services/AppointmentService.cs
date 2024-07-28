using AutoMapper;
using LockNLoad.Model.Constants;
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

        public override async Task<PagedResult<AppointmentResponse>> Get(AppointmentSearchObject search)
        {
            var query = _context.Set<Appointment>().AsQueryable().Include(x => x.TrainingGround).Include(x => x.UserAppointments).AsQueryable();

            if (search != null)
            {
                if (search.TrainingGroundId.HasValue)
                {
                    query = query.Where(x => x.TrainingGroundId == search.TrainingGroundId);
                }
                if (search.Status.HasValue)
                {
                    if (search.Status == Enumerations.AppointmentStatus.Opened)
                    {
                        query = query.Where(x => x.Status == (int)Enumerations.AppointmentStatus.Opened);
                    }
                    if (search.Status == Enumerations.AppointmentStatus.Closed)
                    {
                        query = query.Where(x => x.Status == (int)Enumerations.AppointmentStatus.Closed);
                    }
                }
                if (search.DateFrom.HasValue)
                {
                    query = query.Where(x => x.StartDateTime <= search.DateFrom);
                }
                if (search.DateTo.HasValue)
                {
                    query = query.Where(x => x.EndDateTime >= search.DateTo);
                }
            }

            PagedResult<AppointmentResponse> result = new PagedResult<AppointmentResponse>();

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true && query.Any())
            {
                query = query.Skip((search.Page.Value - 1) * search.PageSize.Value).Take(search.PageSize.Value);
            }

            result.Count = await query.CountAsync();

            var list = await query.ToListAsync();

            result.Result = _mapper.Map<List<AppointmentResponse>>(list);

            return result;
        }
    }
}
