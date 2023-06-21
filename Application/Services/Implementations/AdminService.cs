using Application.Services.Helper;
using Application.Services.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Application.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<User> DeleteUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user != null && userId.ToString() != "e1035f07-bb12-493d-b4a1-715e8eeba867")
            {
                var roleNames = await _userManager.GetRolesAsync(user);

                foreach (var roleName in roleNames)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);

                    if (role != null)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                }

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return user;
                }
                else
                {
                    throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
                }
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }
        }

        public async Task<User> EditUserAsync(Guid userId, EditUserDto model)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                user.Email = model.Email ?? user.Email;
                user.UserName = model.UserName ?? user.UserName;
                user.Surname = model.Surname ?? user.Surname;
                user.PhoneNumber = model.Phone ?? user.PhoneNumber;
                user.Password = model.Password ?? user.Password;

                IdentityResult result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return user;
                }
                else
                {
                    throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
                }
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var result = await _userManager.Users.ToListAsync();

            return result;
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }
        }
    }
}
