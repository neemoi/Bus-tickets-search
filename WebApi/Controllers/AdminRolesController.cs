using Application.Services;
using Application.Services.Helper;
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
        public async Task<IActionResult> CreateRoleAsync([FromBody] string name)
        {
            if (ModelState.IsValid)
            {
                await _adminRolesService.CreateRoleAsync(name);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }

            return Ok();
        }

        [Route("api/DeleteRole")]
        [HttpPost]
        public async Task<IActionResult> DeleteRoleAsync([FromBody] Guid roleId)
        {
            if (ModelState.IsValid)
            {
                await _adminRolesService.DeleteRoleAsync(roleId);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }

            return Ok();
        }
    }
}
