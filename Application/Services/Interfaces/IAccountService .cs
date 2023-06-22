using Application.Services.DtoModels.Response.AccountController;
using Microsoft.AspNetCore.Http;
using WebApi;

namespace Application.Services
{
    public interface IAccountService
    {
        Task<UserLoginResponseDto> LoginAsync(LoginDto model);

        Task<UserRegisterResponseDto> RegisterAsync(RegisterDto model);

        Task<UserLogoutResponseDto> LogoutAsync(HttpContext httpContext);
    }
}
