using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using WebApi.Models;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface ITicketRepository
    {
        Task<Ticket> CreateTicketAsync(Ticket ticket);

        Task<Ticket> EditTicketAsync(uint idTicket, TicketDto model);

        Task<Ticket> DeleteTicketByIdAsync(uint idTicket);

        Task<Ticket> GetByIdTicketAsync(uint idTicket);

        Task<List<Ticket>> GetAllTicketsAsync();
    }
}
