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

        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            else
            {
                throw new ApiRequestError(StatusCodes.Status400BadRequest, GetErrorString(new IdentityResult()));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                Password = model.Password,
                Surname = model.Surname
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded || user != null)
            {
                await _signInManager.SignInAsync(user, true);

                await _userManager.AddToRoleAsync(user, "User");

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            else
            {
                throw new ApiRequestError(StatusCodes.Status400BadRequest, GetErrorString(new IdentityResult()));
            }
        }

        public string GetErrorString(IdentityResult result)
        {
            return string.Join("; ", result.Errors.Select(x => x.Description));
        }
    }
}
