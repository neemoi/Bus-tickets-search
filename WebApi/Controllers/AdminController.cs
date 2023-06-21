using Application.Services.Helper;
using Application.Services.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using WebApi.Models;
using WebApi.RequestError;

namespace WebApi.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminUserController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Route("api/GetAllUsers")]
        [HttpGet]
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
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }
        }

        [HttpPost("api/DeleteUser")]
        public async Task<IActionResult> DeleteUserAsync(Guid userId)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.DeleteUserAsync(userId);

                return Ok(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
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
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }
        }
    }
}