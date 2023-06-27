using Application.Services.DtoModels.DtoModels;
using Application.Services.Helper;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.RequestError;

namespace WebApi.Controllers.Admin
{
    //[Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IAdminUserService _adminService;

        public UserController(IAdminUserService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("api/Users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return Ok(await _adminService.GetAllUsersAsync());
        }

        [HttpGet("api/user/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            return Ok(await _adminService.GetUserByIdAsync(id));
        }

        [HttpPut("api/user/{id}")]
        public async Task<IActionResult> EditUserAsync(Guid id, UserDto model)
        {
            return Ok(await _adminService.EditUserAsync(id, model));
        }

        [HttpDelete("api/user/{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            return Ok(await _adminService.DeleteUserAsync(id));
        }
    }
}