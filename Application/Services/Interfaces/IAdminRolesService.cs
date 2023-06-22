using Application.Services.DtoModels.Response.AdminRolesControllerDto;

namespace Application.Services.Interfaces
{
    public interface IAdminRolesService
    {
        Task<List<AdminRolesGetAllRolesDto>> GetAllRolesAsync();

        Task<AdminRolesAssignUserRoleDto> AssignUserRoleAsync(Guid userId, string roleName);

        Task<AdminRolesCreateRoleDto> CreateRoleAsync(string roleName);

        Task<AdminRolesDeleteRoleDto> DeleteRoleAsync(Guid roleId);

    }
}
