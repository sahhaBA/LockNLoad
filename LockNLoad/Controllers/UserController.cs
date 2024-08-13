using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Model.SearchObjects;
using LockNLoad.Service.Interfaces;
using LockNLoad.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LockNLoad.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class UserController : BaseCRUDController<UserResponse, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
            : base(logger, null)
        {
            _userService = userService;
        }

        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers([FromQuery] UserSearchObject search)
        {
            try
            {
                var model = await _userService.Get(search);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}");
            }
        }

        [HttpPost("RegisterNewUser")]
        public async Task<IActionResult> RegisterNewUser(UserInsertRequest request)
        {
            try
            {
                var success = await _userService.Insert(request);
                if (success != null)
                {
                    return Ok("Appointment added successfully.");
                }
                else
                {
                    return BadRequest("Failed to add appointment.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}");
            }
        }
    }
}
