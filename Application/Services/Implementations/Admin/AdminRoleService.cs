using Application.Services.DtoModels.Response.Admin;
using Application.Services.Helper;
using Application.Services.Interfaces.IServices.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Models;
using WebApi.RequestError;

namespace Application.Services.Implementations.Admin
{
    public class AdminRoleService : IAdminRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AdminRoleService(RoleManager<IdentityRole> roleManager, IMapper mapper, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<RoleResponseDto> CreateRoleAsync(string roleName)
        {
            var role = new IdentityRole(roleName);

            IdentityResult result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return _mapper.Map<RoleResponseDto>(role);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }

        public async Task<RoleResponseDto> DeleteRoleAsync(Guid roleId)
        {
            IdentityRole? role = await _roleManager.FindByIdAsync(roleId.ToString());

            IdentityResult result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded && role != null)
            {
                return _mapper.Map<RoleResponseDto>(role);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }

        public async Task<RoleResponseDto> AssignUserRoleAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            IdentityRole? role = await _roleManager.FindByNameAsync(roleName);

            if (user == null || role == null)
            {
                throw new ApiRequestErrorException(StatusCodes.Status404NotFound, "User or role not found");
            }

            await _userManager.AddToRoleAsync(user, role.Name);

            return _mapper.Map<RoleResponseDto>(user);
        }

        public async Task<List<RoleResponseDto>> GetAllRolesAsync()
        {
            List<IdentityRole> roles = await _roleManager.Roles.ToListAsync();

            var result = roles.Select(u => _mapper.Map<RoleResponseDto>(u)).ToList();

            return result;
        }
    }
}