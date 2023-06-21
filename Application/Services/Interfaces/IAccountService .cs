using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using WebApi.Models;

namespace Application.Services
{
    public interface IAccountService
    {
        Task<User> LoginAsync(LoginDto model);

        Task<User> RegisterAsync(RegisterDto model);

        Task<IActionResult> LogoutAsync();
    }
}
