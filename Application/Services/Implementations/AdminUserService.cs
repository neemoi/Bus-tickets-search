﻿using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;
using Application.Services.Helper;
using Application.Services.Interfaces.IServices;
using AutoMapper;
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

        public async Task<AdminUserResponseDto> DeleteUserAsync(Guid userId)
        {
            var adminId = "e1035f07-bb12-493d-b4a1-715e8eeba867";

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (userId.ToString() == adminId || user == null)
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, new IdentityResult().GetErrorString());
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
                return _mapper.Map<AdminUserResponseDto>(user);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }

        public async Task<AdminUserResponseDto> EditUserAsync(Guid userId, UserDto model)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (result.Succeeded && user != null)
            {
                _mapper.Map(model, user);

                return _mapper.Map<AdminUserResponseDto>(user);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }

        public async Task<List<AdminUserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var result = users.Select(u => _mapper.Map<AdminUserResponseDto>(u)).ToList();

            return result;
        }

        public async Task<AdminUserResponseDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, new IdentityResult().GetErrorString());
            }

            return _mapper.Map<AdminUserResponseDto>(user);
        }
    }
}
