using Application.Services.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using WebApi.Models;
using WebApi.RequestError;

namespace Application.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<User> LoginAsync(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);

            var user = await _signInManager.UserManager.FindByNameAsync(model.Email);

            if (result.Succeeded && user != null)
            {
                return user;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, ErrorString.GetErrorString(new IdentityResult()));
            }
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();

            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        public async Task<User> RegisterAsync(RegisterDto model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.Phone,
                Password = model.Password,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded && user != null)
            {
                await _signInManager.SignInAsync(user, true);

                await _userManager.AddToRoleAsync(user, "User");

                return user;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, result.GetErrorString());
            }
        }
    }
}
