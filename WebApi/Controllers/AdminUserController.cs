using Application.Services.DtoModels.DtoModels.AdminUser;
using Application.Services.Helper;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.RequestError;

namespace WebApi.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private readonly IAdminUserService _adminService;

        public AdminUserController(IAdminUserService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("api/GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await _adminService.GetAllUsersAsync();

            return Ok(result);
        }

        [HttpGet("api/GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync(Guid userId)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.GetUserByIdAsync(userId);

                return Ok(result);
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
                var result = await _adminService.DeleteUserAsync(userId);

                return Ok(result);
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
                var result = await _adminService.EditUserAsync(userId, model);

                return Ok(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, new IdentityResult().GetErrorString());
            }
        }
    }
}