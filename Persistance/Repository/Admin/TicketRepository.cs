using Application.DtoModels.Models.Admin;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.Admin
{
    public class TicketRepository : ITicketRepository
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public TicketRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            var result = await _btsContext.Tickets.AddAsync(ticket);

            if (result != null && ticket != null)
            {
                await _btsContext.SaveChangesAsync();

                return ticket;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }

        public async Task<Ticket> DeleteTicketByIdAsync(uint idTicket)
        {
            var ticket = await _btsContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == idTicket);

            if (ticket != null)
            {
                _btsContext.Tickets.Remove(ticket);

                await _btsContext.SaveChangesAsync();

                return ticket;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }

        public async Task<Ticket> EditTicketAsync(uint idTicket, TicketDto model)
        {
            var result = await _btsContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == idTicket);

            if (result != null)
            {
                _mapper.Map(model, result);

                await _btsContext.SaveChangesAsync();

                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            var result = await _btsContext.Tickets.ToListAsync();

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }

        public async Task<Ticket> GetByIdTicketAsync(uint idTicket)
        {
            var ticket = await _btsContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == idTicket);

            if (ticket != null)
            {
                return ticket;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }
    }
}
