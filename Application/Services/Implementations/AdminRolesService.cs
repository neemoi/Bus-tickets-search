using Application.Services.Helper;
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

        public AdminRolesService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> CreateRoleAsync([FromBody] string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

            if (result.Succeeded)
            {
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }

        public async Task<IActionResult> DeleteRoleAsync([FromBody] Guid roleId)
        {
            IdentityRole? role = await _roleManager.FindByIdAsync(roleId.ToString());

            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return new StatusCodeResult(StatusCodes.Status200OK);
                }
                else
                {
                    throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
                }
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status404NotFound, "Role not found");
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
    }
}