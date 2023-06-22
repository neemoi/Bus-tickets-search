using Application.Services.DtoModels.Response.AdminControllerDto;
using Domain.ViewModels;

namespace Application.Services.Interfaces
{
    public interface IAdminUserService
    {
        Task<AdminUserEditUserResponseDto> EditUserAsync(Guid userId, EditUserDto model);

        Task<List<AdminUserGetAllUsersResponseDto>> GetAllUsersAsync();

        Task<AdminUserGetByIdUsersResponseDto> GetUserByIdAsync(Guid userId);

        Task<AdminUserDeleteUserResponseDto> DeleteUserAsync(Guid userId);
    }
}