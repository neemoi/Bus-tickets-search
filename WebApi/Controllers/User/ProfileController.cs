using Application.Services.DtoModels.Models.User;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers.User
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("api/Profile")]
        [Authorize]
        public async Task<IActionResult> GetAllInfoAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(await _profileService.GetAllInfoAsync(userId));
        }

        [HttpPut("api/Profile")]
        [Authorize]
        public async Task<IActionResult> EditProfileAsync(EditProfileDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(await _profileService.EditProfileAsync(model, userId));
        }
    }
}
