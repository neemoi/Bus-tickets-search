using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace Application.Services.Interfaces
{
    public interface IAdminService
    {
        Task<User> EditUserAsync(Guid userId, EditUserDto model);

        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(Guid userId);

        Task<User> DeleteUserAsync(Guid userId);
    }
}