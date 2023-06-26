using Application.Services.DtoModels.Response.AdminRolesControllerDto;
using Application.Services.Helper;
using Application.Services.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Models;
using WebApi.RequestError;

namespace Application.Services.Implementations
{
    public class AdminRolesService : IAdminRolesService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AdminRolesService(RoleManager<IdentityRole> roleManager, IMapper mapper, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AdminRolesCreateRoleDto> CreateRoleAsync(string roleName)
        {
            var role = new IdentityRole(roleName);

            IdentityResult result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return _mapper.Map<AdminRolesCreateRoleDto>(role);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }

        public async Task<AdminRolesDeleteRoleDto> DeleteRoleAsync(Guid roleId)
        {
            IdentityRole? role = await _roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                throw new ApiRequestErrorException(StatusCodes.Status404NotFound, "Role not found");
            }

            IdentityResult result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return _mapper.Map<AdminRolesDeleteRoleDto>(role);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }

        public async Task<AdminRolesAssignUserRoleDto> AssignUserRoleAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            IdentityRole? role = await _roleManager.FindByNameAsync(roleName);

            if (user == null || role == null)
            {
                throw new ApiRequestErrorException(StatusCodes.Status404NotFound, "User or role not found");
            }

            await _userManager.AddToRoleAsync(user, role.Name);

            return new AdminRolesAssignUserRoleDto
            {
                Name = role.Name,
                Id = user.Id
            };
        }

        public async Task<List<AdminRolesGetAllRolesDto>> GetAllRolesAsync()
        {
            List<IdentityRole> roles = await _roleManager.Roles.ToListAsync();

            var result = roles.Select(u => _mapper.Map<AdminRolesGetAllRolesDto>(u)).ToList();

            return result;
        }
    }
}