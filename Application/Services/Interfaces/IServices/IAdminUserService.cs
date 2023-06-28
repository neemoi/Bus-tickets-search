using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IServices
{
    public interface IAdminUserService
    {
        Task<UserResponseDto> EditUserAsync(Guid userId, UserDto model);

        Task<List<UserResponseDto>> GetAllUsersAsync();

        Task<UserResponseDto> GetUserByIdAsync(Guid userId);

        Task<UserResponseDto> DeleteUserAsync(Guid userId);
    }
}