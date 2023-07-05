using Application.Services.DtoModels.Models.User;
using Application.Services.DtoModels.Response.User;
using Application.Services.Helper;
using Application.Services.Interfaces.IServices.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WebApi.RequestError;
using WebApi.Models;
using AutoMapper;

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
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);

            var user = await _signInManager.UserManager.FindByNameAsync(model.UserName);

            if (result.Succeeded && user != null)
            {
                return _mapper.Map<LoginResponseDto>(user);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Login");
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

            var emailAlreadyExists = await _userManager.FindByEmailAsync(user.Email);

            if (emailAlreadyExists != null)
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "A user with this email already exists");
            }

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