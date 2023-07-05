using Application.Services.DtoModels.Response.User;

namespace Application.Services.Interfaces.IRepository.User
{
    public interface IOrderManagementRepository
    {
        Task<InfoTicketResponseDto> GetInfoByIdTicketAsync(string idUser);

        Task<InfoTicketResponseDto> TicketCancelAtionAsync(string idUser);
    }
}