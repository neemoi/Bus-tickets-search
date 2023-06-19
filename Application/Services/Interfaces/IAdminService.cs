using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Application.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IActionResult> GetAllUsers();

        Task<IActionResult> EditUser(Guid id, EditUserModel model);

        Task<IActionResult> AddUser(AddUserModel model);

        Task<ActionResult> DeleteUser(Guid id);

        string GetErrorString(IdentityResult result);
    }
}
