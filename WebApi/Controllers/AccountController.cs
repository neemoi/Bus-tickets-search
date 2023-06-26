using Application.Services.DtoModels.DtoModels;
using Application.Services.Helper;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> LoginAsync(LoginDto model)
        {
            var userLoginDto = await _accountService.LoginAsync(model);

            return Ok(userLoginDto);
        }

        [Route("api/Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var userRegisterDto = await _accountService.RegisterAsync(model);

                return Ok(userRegisterDto);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, new IdentityResult().GetErrorString());
            }
        }

        [Route("api/Logout")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogoutAsync()
        {
            var userLogoutDto = await _accountService.LogoutAsync(HttpContext);

            return Ok(userLogoutDto);
        }
    }
}
