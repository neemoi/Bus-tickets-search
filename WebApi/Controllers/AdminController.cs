using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.RequestError;

namespace WebApi.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<User> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Route("api/UserList")]
        [HttpGet]
        public IActionResult UserList()
        {
            var result = _userManager.Users.ToList();

            return Ok(result);
        }

        [Route("api/AssignUserRole")]
        [HttpPost]
        public async Task<IActionResult> AssignUserRole([FromBody] Guid userId)
        {
            User? user = await _userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
               
            }

            return Ok();
        }

        [Route("api/RoleList")]
        [HttpGet]
        public IActionResult RoleList()
        {
            var result = _roleManager.Roles.ToList();

            return Ok(result); 
        }

        [Route("api/CreateRole")]
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

                if (!result.Succeeded)
                {
                    return BadRequest(GetErrorString(result));
                }
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
            IdentityRole? role = await _roleManager.FindByIdAsync(roleId.ToString());

            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            else
            {
                throw new ApiRequestError(0, "Role is NULL");
            }

            return Ok();
        }

        private static string GetErrorString(IdentityResult result)
        {
            return string.Join("; ", result.Errors.Select(x => x.Description));
        }
    }
}