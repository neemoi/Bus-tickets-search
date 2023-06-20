using Application.Services;
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
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            return await _accountService.LoginAsync(model);
        }

        [Route("api/Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
               return await _accountService.RegisterAsync(model);
            }

            return BadRequest(ModelState);
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
