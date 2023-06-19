using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.RequestError;

namespace Application.Services.Implementations
{
    public class AdminRolesService : IAdminRolesService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminRolesService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> CreateRole([FromBody] string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

            if (result.Succeeded)
            {
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            else
            {
                throw new ApiRequestError(StatusCodes.Status400BadRequest, GetErrorString(result));
            }
        }

        public async Task<IActionResult> DeleteRole([FromBody] Guid roleId)
        {
            IdentityRole? role = await _roleManager.FindByIdAsync(roleId.ToString());

            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return new StatusCodeResult(StatusCodes.Status204NoContent);
                }
                else
                {
                    throw new ApiRequestError(StatusCodes.Status400BadRequest, GetErrorString(result));
                }
            }
            else
            {
                throw new ApiRequestError(StatusCodes.Status404NotFound, "Role not found");
            }
        }

        public Task<IActionResult> AssignUserRole([FromBody] Guid userId)
        {
            throw new NotImplementedException();
        }

        public IActionResult RoleList()
        {
            List<IdentityRole> roles = _roleManager.Roles.ToList();

            return new ObjectResult(roles) { StatusCode = StatusCodes.Status200OK };
        }

        public string GetErrorString(IdentityResult result)
        {
            return string.Join("; ", result.Errors.Select(x => x.Description));
        }
    }
}