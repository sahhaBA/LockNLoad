using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Model.SearchObjects;
using LockNLoad.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LockNLoad.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : BaseCRUDController<RoleResponse, RoleSearchObject, RoleInsertRequest, RoleUpdateRequest>
    {
        public DashboardController(ILogger<BaseController<RoleResponse, RoleSearchObject>> logger, IRoleService service) : base(logger, service)
        {

        }

        [HttpGet("testConnection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                var model = await _service.GetAll();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}");
            }
        }
    }
}
