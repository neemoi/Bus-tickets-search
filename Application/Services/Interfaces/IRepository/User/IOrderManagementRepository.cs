using Application.Services.DtoModels.Response.User;

namespace Application.Services.Interfaces.IRepository.User
{
    public interface IOrderManagementRepository
    {
        Task<InfoOrderResponseDto> GetInfoByIdTicketAsync(string idUser);

        Task<InfoOrderResponseDto> CancelOrderAsync(string idUser);
    }
}