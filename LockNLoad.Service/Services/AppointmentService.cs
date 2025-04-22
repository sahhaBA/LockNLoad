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
        private readonly IAppointmentService _appointmentService;
        private readonly ITrainingGroundService _trainingGroundService;

        public AppointmentService(LockNLoadContext context, IAppointmentService appointmentService, ITrainingGroundService trainingGroundService, IMapper mapper)
            : base(context, mapper)
        {
            _appointmentService = appointmentService;
            _trainingGroundService = trainingGroundService;
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

        public override async Task<AppointmentResponse> Insert(AppointmentInsertRequest request)
        {
            var set = _context.Set<Appointment>();

            Appointment entity = _mapper.Map<Appointment>(request);

            set.Add(entity);
            await BeforeInsert(entity, request);

            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentResponse>(entity);
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

        public async Task<bool> Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                var userAppointments = await _context.UserAppointments
                    .Where(t => t.AppointmentId == id).ToListAsync();

                if (userAppointments?.Any() == true)
                {
                    var userAppointmentEquipment = await _context.UserAppointmentEquipments
                        .Where(t => userAppointments.Any(x => x.Id == t.UserAppointmentId)).ToListAsync();

                    var requests = await _context.Requests
                        .Where(t => userAppointments.Any(x => x.RequestId == t.Id)).ToListAsync();

                    if(requests?.Any() == true)
                    {
                        var bills = await _context.Bills
                            .Where(t => requests.Any(x => x.Id == t.RequestId)).ToListAsync();

                        var reviews = await _context.Reviews
                            .Where(t => requests.Any(x => x.ReviewId == t.Id)).ToListAsync();

                        _context.Bills.RemoveRange(bills);
                        _context.Requests.RemoveRange(requests);
                        _context.Reviews.RemoveRange(reviews);
                    }

                    _context.UserAppointmentEquipments.RemoveRange(userAppointmentEquipment);
                    _context.UserAppointments.RemoveRange(userAppointments);
                }

                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<AppointmentDetailResponse> GetDetailsByAppointmentIdAsync(int appointmentId)
        {
            var appointment = await _appointmentService.GetById(appointmentId);
            var trainingGround = await _trainingGroundService.GetById(appointment.TrainingGroundId);

            var model = new AppointmentDetailResponse
            {
                AppointmentId = appointment.Id,
                TrainingGroundId = appointment.TrainingGroundId,
                TrainingGroundName = trainingGround.Name,
                TrainingGroundLocation = trainingGround.Location,
                TrainingGroundLocationImageUrl = trainingGround.LocationImageUrl,
                Date = DateOnly.FromDateTime(appointment.StartDateTime ?? DateTime.Now),
                StartTime = TimeOnly.FromDateTime(appointment.StartDateTime ?? DateTime.Now),
                EndDate = TimeOnly.FromDateTime(appointment.EndDateTime ?? DateTime.Now),
                NumberOfParticipants = 0,
                MaxParticipants = appointment.MaxParticipants ?? 0,
                Status = appointment.Status == Enumerations.AppointmentStatus.Opened ? "Aktivan" : "Završen",
                Description = appointment.Description
            };

            return model;
        }
    }
}
