using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface ITicketRepository
    {
        Task<TicketResponseDto> CreateTicketAsync(TicketDto model);

        Task<TicketResponseDto> EditTicketAsync(uint idTicket, TicketDto model);

        Task<TicketResponseDto> DeleteTicketByIdAsync(uint idTicket);

        Task<TicketResponseDto> GetByIdTicketAsync(uint idTicket);

        Task<List<TicketResponseDto>> GetAllTicketsAsync();
    }
}
