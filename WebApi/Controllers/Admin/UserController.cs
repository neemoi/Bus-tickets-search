using Application.Services.DtoModels.DtoModels.AdminUser;
using Application.Services.Helper;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
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

        [HttpGet("api/GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return Ok(await _adminService.GetAllUsersAsync());
        }

        [HttpGet("api/GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync(Guid userId)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _adminService.GetUserByIdAsync(userId));
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, new IdentityResult().GetErrorString());
            }
        }

        [HttpPost("api/EditUser")]
        public async Task<IActionResult> EditUserAsync(Guid userId, EditUserDto model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _adminService.EditUserAsync(userId, model));
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, new IdentityResult().GetErrorString());
            }
        }

        [HttpDelete("api/DeleteUser")]
        public async Task<IActionResult> DeleteUserAsync(Guid userId)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _adminService.DeleteUserAsync(userId));
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, new IdentityResult().GetErrorString());
            }
        }
    }
}