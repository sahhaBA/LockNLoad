using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Model.SearchObjects;
using LockNLoad.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LockNLoad.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class AppointmentController : BaseCRUDController<AppointmentResponse, AppointmentSearchObject, AppointmentInsertRequest, AppointmentUpdateRequest>
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentService appointmentService)
            : base(logger, null)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("getAppointments")]
        public async Task<IActionResult> GetAppointments([FromQuery] AppointmentSearchObject search)
        {
            try
            {
                var model = await _appointmentService.Get(search);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}");
            }
        }

        [HttpDelete("deleteAppointment")]
        public async Task<IActionResult> DeleteAppointment(int appointmentId)
        {
            try
            {
                bool success = await _appointmentService.Delete(appointmentId);
                if (success)
                {
                    return NoContent(); 
                }
                return NotFound(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
