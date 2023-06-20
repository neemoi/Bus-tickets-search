using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;

namespace Application.Services
{
    public interface IAccountService
    {
        Task<IActionResult> LoginAsync(LoginModel model);

        Task<IActionResult> RegisterAsync(RegisterModel model);

        Task<IActionResult> LogoutAsync();

        string GetErrorString(IdentityResult result);
    }
}
