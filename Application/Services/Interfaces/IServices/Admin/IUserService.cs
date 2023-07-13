using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IUserService
    {
        Task<UserResponseDto> EditUserAsync(Guid userId, UserDto model);

        Task<List<UserResponseDto>> GetAllUsersAsync();

        Task<UserResponseDto> GetUserByIdAsync(Guid userId);

        Task<UserResponseDto> DeleteUserAsync(Guid userId);
    }
}