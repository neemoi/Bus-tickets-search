using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApi.Models;
using WebApi.RequestError;

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

        //[Route("api/AssignUserRole")]
        //[HttpPost]
        //public async Task<IActionResult> AssignUserRole([FromBody] string userId)
        //{
        //    return Ok();
        //}

        [Route("api/RoleList")]
        [HttpGet]
        public IActionResult RoleList()
        {
            var result = _adminRolesService.RoleList();

            return Ok(result);
        }

        [Route("api/CreateRole")]
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string name)
        {
            if (ModelState.IsValid)
            {
                await _adminRolesService.CreateRole(name);
            }
            else
            {
                throw new ApiRequestError(0, "Role is empty");
            }

            return Ok();
        }

        [Route("api/DeleteRole")]
        [HttpPost]
        public async Task<IActionResult> DeleteRole([FromBody] Guid roleId)
        {
            if (ModelState.IsValid)
            {
                await _adminRolesService.DeleteRole(roleId);
            }
            else
            {
                throw new ApiRequestError(0, "Role is empty");
            }

            return Ok();
        }
    }
}
