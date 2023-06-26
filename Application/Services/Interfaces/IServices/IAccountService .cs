using Application.Services.DtoModels.DtoModels.LoginAndRegister;
using Application.Services.DtoModels.Response.AccountController;
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
