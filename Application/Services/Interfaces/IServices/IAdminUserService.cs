using Application.Services.DtoModels.DtoModels;
using Application.Services.DtoModels.Response;

namespace Application.Services.Interfaces.IServices
{
    public interface IAdminUserService
    {
        Task<AdminUserResponseDto> EditUserAsync(Guid userId, UserDto model);

        Task<List<AdminUserResponseDto>> GetAllUsersAsync();

        Task<AdminUserResponseDto> GetUserByIdAsync(Guid userId);

        Task<AdminUserResponseDto> DeleteUserAsync(Guid userId);
    }
}