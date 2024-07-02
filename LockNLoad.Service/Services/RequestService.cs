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
using static LockNLoad.Model.Constants.Enumerations;

namespace LockNLoad.Service.Services
{
    public class RequestService : BaseCRUDService<RequestResponse, Request, RequestSearchObject, RequestInsertRequest, RequestUpdateRequest>, IRequestService
    {
        public RequestService(LockNLoadContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<List<RequestDto>> GetLatestRequests()
        {
            return await _context.Requests.OrderByDescending(x => x.RecordDateTime)
                                          .Select(a => new RequestDto
                                          {
                                              Type = a.UserAppointments.FirstOrDefault().Appointment.IsBooked == true ? RequestTypes.Booked : RequestTypes.Applied,
                                              User = new UserBasicDto
                                              {
                                                  FirstName = a.UserAppointments.FirstOrDefault().User.FirstName,
                                                  LastName = a.UserAppointments.FirstOrDefault().User.LastName,
                                                  UserName = a.UserAppointments.FirstOrDefault().User.Username,
                                                  ProfileImageUrl = a.UserAppointments.FirstOrDefault().User.ProfileImageUrl
                                              },
                                              Credit = (double?)a.Bills.FirstOrDefault().Amount ?? 0,
                                              RequestDate = a.RecordDateTime.Value,
                                              Status = a.ApprovedDateTime.HasValue ? RequestStatuses.Approved : a.RejectedDateTime.HasValue ? RequestStatuses.Rejected : RequestStatuses.Pending 
                                          }).Take(10).ToListAsync();
        }

        public async Task<int> GetTotalPendingRequests()
        {
            return await _context.Requests.Where(x => !x.ApprovedBy.HasValue && !x.RejectedBy.HasValue).CountAsync();
        }
    }
}
