using Application.Services.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.RequestError;

namespace Application.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<User> _userManager;

        public AdminService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public Task<IActionResult> AddUser(AddUserModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> EditUser(Guid id, EditUserModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetAllUsers()
        {
            List<User> users = await _userManager.Users.ToListAsync();

            return new ObjectResult(users) { StatusCode = StatusCodes.Status200OK };
        }

        public string GetErrorString(IdentityResult result)
        {
            return string.Join("; ", result.Errors.Select(x => x.Description));
        }
    }
}
