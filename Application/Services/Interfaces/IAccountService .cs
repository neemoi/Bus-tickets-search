using Application.Services.DtoModels.Response.AccountController;
using Microsoft.AspNetCore.Http;
using WebApi;

namespace Application.Services
{
    public interface IAccountService
    {
        Task<UserLoginResponceDto> LoginAsync(LoginDto model);

        Task<UserRegisterResponceDto> RegisterAsync(RegisterDto model);

        Task<UserLogoutResponceDto> LogoutAsync(HttpContext httpContext);
    }
}
