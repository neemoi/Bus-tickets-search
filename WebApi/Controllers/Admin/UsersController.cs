﻿using Application.DtoModels.Models.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _adminService;

        public UsersController(IUserService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("api/User")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return Ok(await _adminService.GetAllUsersAsync());
        }

        [HttpGet("api/User/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            return Ok(await _adminService.GetUserByIdAsync(id));
        }

        [HttpPut("api/User/{id}")]
        public async Task<IActionResult> EditUserAsync(Guid id, UserDto model)
        {
            return Ok(await _adminService.EditUserAsync(id, model));
        }

        [HttpDelete("api/User/{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            return Ok(await _adminService.DeleteUserAsync(id));
        }
    }
}