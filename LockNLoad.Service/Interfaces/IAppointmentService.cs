using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Service.Interfaces
{
    public interface IAppointmentService : ICRUDService<AppointmentResponse, AppointmentSearchObject, AppointmentInsertRequest, AppointmentUpdateRequest>
    {
        Task<int> GetTotalActiveAppointments();
        Task<int> GetTotalNumberOfAppointmentsForCurrentMonth();
        Task<bool> Delete(int appointmentId);
        Task<AppointmentDetailResponse> GetDetailsByAppointmentIdAsync(int appointmentId);
    }
}
