using Application.Services;
using Application.Services.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using WebApi.Models;
using WebApi.RequestError;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("api/Login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<User> LoginAsync(LoginDto model)
        {
            return await _accountService.LoginAsync(model);
        }

        [Route("api/Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<User> RegisterAsync(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.RegisterAsync(model);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));

            }
        }

        [Route("api/Logout")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogoutAsync()
        {
            return await _accountService.LogoutAsync();
        }
    }
}
