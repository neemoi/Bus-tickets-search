using Application.Services.DtoModels.Response;

namespace Application.Services.Interfaces.IServices
{
    public interface IAdminRolesService
    {
        Task<List<AdminRoleDto>> GetAllRolesAsync();

        Task<AdminRoleDto> AssignUserRoleAsync(Guid userId, string roleName);

        Task<AdminRoleDto> CreateRoleAsync(string roleName);

        Task<AdminRoleDto> DeleteRoleAsync(Guid roleId);

    }
}
