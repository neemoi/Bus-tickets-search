using Application.Services.DtoModels.Models.User;
using Application.Services.DtoModels.Response.User;
using Application.Services.Helper;
using Application.Services.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WebApi.Models;
using WebApi.RequestError;

namespace Application.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);

            var user = await _signInManager.UserManager.FindByNameAsync(model.Email);

            if (result.Succeeded && user != null)
            {
                return _mapper.Map<LoginResponseDto>(user);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, new IdentityResult().GetErrorString());
            }
        }

        public async Task<LogoutResponseDto> LogoutAsync(HttpContext httpContext)
        {
            var user = await _userManager.GetUserAsync(httpContext.User);

            await _signInManager.SignOutAsync();

            return _mapper.Map<LogoutResponseDto>(user);
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterDto model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded && user != null)
            {
                await _signInManager.SignInAsync(user, true);

                await _userManager.AddToRoleAsync(user, "User");

                return _mapper.Map<RegisterResponseDto>(user);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }
    }
}