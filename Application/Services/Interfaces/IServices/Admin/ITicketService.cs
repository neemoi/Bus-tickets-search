using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface ITicketService
    {
        Task<TicketResponseDto> CreateTicketAsync(TicketDto model);

        Task<TicketResponseDto> EditTicketAsync(uint idTicket, TicketDto model);

        Task<TicketResponseDto> DeleteTicketByIdAsync(uint idTicket);

        Task<TicketResponseDto> GetByIdTicketAsync(uint idTicket);

        Task<List<TicketResponseDto>> GetAllTicketsAsync();
    }
}
