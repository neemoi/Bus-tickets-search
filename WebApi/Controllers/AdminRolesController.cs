using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminRolesController : Controller
    {
        private readonly IAdminRolesService _adminRolesService;

        public AdminRolesController(IAdminRolesService adminRolesService)
        {
            _adminRolesService = adminRolesService;
        }

        [Route("api/GetAllRoles")]
        [HttpGet]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var result = await _adminRolesService.GetAllRolesAsync();

            return Ok(result);
        }

        [Route("api/CreateRole")]
        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync(string name)
        {
            var result = await _adminRolesService.CreateRoleAsync(name);

            return Ok(result);
        }

        [Route("api/DeleteRole")]
        [HttpPost]
        public async Task<IActionResult> DeleteRoleAsync(Guid roleId)
        {
            var result = await _adminRolesService.DeleteRoleAsync(roleId);

            return Ok(result);
        }

        [Route("api/AssignUserRole")]
        [HttpPost]
        public async Task<IActionResult> AssignUserRoleAsync(Guid userId, string role)
        {
            var result = await _adminRolesService.AssignUserRoleAsync(userId, role);

            return Ok(result);
        }
    }
}
