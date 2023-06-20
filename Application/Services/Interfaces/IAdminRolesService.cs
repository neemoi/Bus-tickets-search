using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAdminRolesService
    {
        Task<IActionResult> AssignUserRole([FromBody] Guid userId);

        public IActionResult RoleList();

        string GetErrorString(IdentityResult result);

        Task<IActionResult> CreateRoleAsync([FromBody] string name);

        Task<IActionResult> DeleteRoleAsync([FromBody] Guid roleId);

    }
}
