using Application.Services.DtoModels.Response.AdminControllerDto;
using Application.Services.Helper;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Application.Services.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AdminUserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<AdminUserDeleteUserResponseDto> DeleteUserAsync(Guid userId)
        {
            var adminId = "e1035f07-bb12-493d-b4a1-715e8eeba867";

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (userId.ToString() == adminId || user == null)
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }

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
                return _mapper.Map<AdminUserDeleteUserResponseDto>(user);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }

        public async Task<AdminUserEditUserResponseDto> EditUserAsync(Guid userId, EditUserDto model)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }

            user.Email = model.Email ?? user.Email;
            user.UserName = model.UserName ?? user.UserName;
            user.Surname = model.Surname ?? user.Surname;
            user.PhoneNumber = model.Phone ?? user.PhoneNumber;
            user.Password = model.Password ?? user.Password;

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return _mapper.Map<AdminUserEditUserResponseDto>(user);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }

        public async Task<List<AdminUserGetAllUsersResponseDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var result = users.Select(u => _mapper.Map<AdminUserGetAllUsersResponseDto>(u)).ToList();

            return result;
        }

        public async Task<AdminUserGetByIdUsersResponseDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }

            return _mapper.Map<AdminUserGetByIdUsersResponseDto>(user);
        }
    }
}
