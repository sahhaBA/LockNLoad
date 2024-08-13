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
    public class DashboardController : BaseController<DashboardResponse, object>
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(ILogger<DashboardController> logger, IDashboardService dashboardService)
            : base(logger, null)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("DashboardPreview")]
        public async Task<IActionResult> GetDashboardPreview()
        {
            try
            {
                var model = await _dashboardService.GetDashboardDataAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}");
            }
        }
    }
}
