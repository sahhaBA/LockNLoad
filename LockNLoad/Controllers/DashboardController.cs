using LockNLoad.Service.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LockNLoad.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly LockNLoadContext _context;

        public DashboardController(LockNLoadContext context)
        {
            _context = context;
        }

        [HttpGet("testConnection")]
        public IActionResult TestConnection()
        {
            try
            {
                _context.Database.OpenConnection();
                _context.Database.CloseConnection();
                return Ok("Connection successful!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}");
            }
        }
    }
}
