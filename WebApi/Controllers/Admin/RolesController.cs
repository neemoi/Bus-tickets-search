using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers.Admin
{
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly IAdminRolesService _adminRolesService;

        public RolesController(IAdminRolesService adminRolesService)
        {
            _adminRolesService = adminRolesService;
        }

        [HttpGet("api/GetAllRoles")]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            return Ok(await _adminRolesService.GetAllRolesAsync());
        }

        [HttpPost("api/CreateRole")]
        public async Task<IActionResult> CreateRoleAsync(string name)
        {
            return Ok(await _adminRolesService.CreateRoleAsync(name));
        }

        [HttpPost("api/AssignUserRole")]
        public async Task<IActionResult> AssignUserRoleAsync(Guid userId, string role)
        {
            return Ok(await _adminRolesService.AssignUserRoleAsync(userId, role));
        }

        [HttpDelete("api/DeleteRole")]
        public async Task<IActionResult> DeleteRoleAsync(Guid roleId)
        {
            return Ok(await _adminRolesService.DeleteRoleAsync(roleId));
        }
    }
}
