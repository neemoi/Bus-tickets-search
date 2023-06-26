using Application.Services.DtoModels.DtoModels.LoginAndRegister;
using Application.Services.Helper;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.RequestError;

namespace WebApi.Controllers.User
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

        [HttpPost("api/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _accountService.LoginAsync(model));
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, new IdentityResult().GetErrorString());
            }
        }

        [HttpPost("api/Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _accountService.RegisterAsync(model));
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, new IdentityResult().GetErrorString());
            }
        }

        [HttpPost("api/Logout")]
        [AllowAnonymous]
        public async Task<IActionResult> LogoutAsync()
        {
            return Ok(await _accountService.LogoutAsync(HttpContext));
        }
    }
}
