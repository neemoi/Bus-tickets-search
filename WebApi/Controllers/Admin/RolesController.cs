using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers.Admin
{
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly IAdminRoleService _adminRolesService;

        public RolesController(IAdminRoleService adminRolesService)
        {
            _adminRolesService = adminRolesService;
        }

        [HttpGet("api/Role")]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            return Ok(await _adminRolesService.GetAllRolesAsync());
        }

        [HttpPost("api/Role")]
        public async Task<IActionResult> CreateRoleAsync(string name)
        {
            return Ok(await _adminRolesService.CreateRoleAsync(name));
        }

        [HttpPut("api/Role/{id}")]
        public async Task<IActionResult> AssignUserRoleAsync(Guid id, string role)
        {
            return Ok(await _adminRolesService.AssignUserRoleAsync(id, role));
        }

        [HttpDelete("api/Role/{id}")]
        public async Task<IActionResult> DeleteRoleAsync(Guid id)
        {
            return Ok(await _adminRolesService.DeleteRoleAsync(id));
        }
    }
}