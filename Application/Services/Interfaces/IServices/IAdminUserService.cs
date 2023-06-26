using Application.Services.DtoModels.DtoModels;
using Application.Services.DtoModels.Response.AdminControllerDto;

namespace Application.Services.Interfaces.IServices
{
    public interface IAdminUserService
    {
        Task<AdminUserEditUserResponseDto> EditUserAsync(Guid userId, EditUserDto model);

        Task<List<AdminUserGetAllUsersResponseDto>> GetAllUsersAsync();

        Task<AdminUserGetByIdUsersResponseDto> GetUserByIdAsync(Guid userId);

        Task<AdminUserDeleteUserResponseDto> DeleteUserAsync(Guid userId);
    }
}