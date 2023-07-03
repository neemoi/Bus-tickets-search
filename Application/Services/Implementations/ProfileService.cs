using Application.Services.DtoModels.Models.User;
using Application.Services.DtoModels.Response.User;
using Application.Services.Interfaces.IServices.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApi.Models;

namespace Application.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ProfileService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<EditProfileResposneDto> EditProfileAsync(EditProfileDto model, string idUser)
        {
            var user = await _userManager.FindByIdAsync(idUser);

            if (user != null)
            {
                if (!string.IsNullOrEmpty(model.Password))
                {
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

                    if (!changePasswordResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Error changing password: {string.Join(", ", changePasswordResult.Errors.Select(e => e.Description))}");
                    }
                }

                _mapper.Map(model, user);

                var updateResult = await _userManager.UpdateAsync(user);

                if (updateResult.Succeeded)
                {
                    return _mapper.Map<EditProfileResposneDto>(user);
                }
                else
                {
                    throw new InvalidOperationException($"Error updating user profile: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                throw new ArgumentNullException($"User null");
            }
        }

        public async Task<EditProfileResposneDto> GetAllInfoAsync(string idUser)
        {
            var user = await _userManager.FindByIdAsync(idUser);

            if (user != null)
            {
                return _mapper.Map<EditProfileResposneDto>(user);
            }
            else
            {
                throw new ArgumentNullException($"User with id {idUser} not found.");
            }
        }
    }
}
