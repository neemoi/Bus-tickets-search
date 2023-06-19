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
        Task<IActionResult> Login(LoginModel model);

        Task<IActionResult> Register(RegisterModel model);

        Task<IActionResult> Logout();

        string GetErrorString(IdentityResult result);
    }
}
