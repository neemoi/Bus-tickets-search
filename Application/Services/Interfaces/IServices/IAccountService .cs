using Application.Services.DtoModels.Models.User;
using Application.Services.DtoModels.Response.User;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<UserLoginResponseDto> LoginAsync(LoginDto model);

        Task<UserRegisterResponseDto> RegisterAsync(RegisterDto model);

        Task<UserLogoutResponseDto> LogoutAsync(HttpContext httpContext);
    }
}
