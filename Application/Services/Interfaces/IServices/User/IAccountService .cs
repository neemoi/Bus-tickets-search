using Application.DtoModels.Models.User;
using Application.DtoModels.Response.User;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Interfaces.IServices.User
{
    public interface IAccountService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto model);

        Task<RegisterResponseDto> RegisterAsync(RegisterDto model);

        Task<LogoutResponseDto> LogoutAsync(HttpContext httpContext);
    }
}