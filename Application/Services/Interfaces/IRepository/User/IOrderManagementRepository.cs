using Application.Services.DtoModels.Response.User;

namespace Application.Services.Interfaces.IRepository.User
{
    public interface IOrderManagementRepository
    {
        Task<InfoTicketResponseDto> GetInfoTicketAsync(string idUser);

        Task<InfoTicketResponseDto> TicketCancellationAsync(string idUser);
    }
}
