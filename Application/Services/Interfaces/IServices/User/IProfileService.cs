using Application.DtoModels.Models.User;
using Application.DtoModels.Response.User;

namespace Application.Services.Interfaces.IServices.User
{
    public interface IProfileService
    {
        Task<EditProfileResposneDto> EditProfileAsync(EditProfileDto model, string idUser);

        Task<EditProfileResposneDto> GetAllInfoAsync(string idUser);
    }
}