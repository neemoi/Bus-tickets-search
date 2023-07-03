using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;
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

        public async Task<TicketResponseDto> CreateTicketAsync(TicketDto model)
        {
            var ticket = _mapper.Map<Ticket>(model);

            var result = await _btsContext.Tickets.AddAsync(ticket);

            if (result != null && ticket != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<TicketResponseDto>(ticket);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }

        public async Task<TicketResponseDto> DeleteTicketByIdAsync(uint idTicket)
        {
            var ticket = await _btsContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == idTicket);

            if (ticket != null)
            {
                _btsContext.Tickets.Remove(ticket);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<TicketResponseDto>(ticket);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }

        public async Task<TicketResponseDto> EditTicketAsync(uint idTicket, TicketDto model)
        {
            var ticket = await _btsContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == idTicket);

            if (ticket != null)
            {
                _mapper.Map(model, ticket);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<TicketResponseDto>(ticket);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }

        public async Task<List<TicketResponseDto>> GetAllTicketsAsync()
        {
            var result = await _btsContext.Tickets.ToListAsync();

            if (result != null)
            {
                var mappedTickets = new List<TicketResponseDto>();

                foreach (var ticket in result)
                {
                    var mappedTicket = _mapper.Map<TicketResponseDto>(ticket);

                    mappedTickets.Add(mappedTicket);
                }

                return mappedTickets;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");

            }
        }

        public async Task<TicketResponseDto> GetByIdTicketAsync(uint idTicket)
        {
            var ticket = await _btsContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == idTicket);

            if (ticket != null)
            {
                return _mapper.Map<TicketResponseDto>(ticket);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }

            throw new NotImplementedException();
        }
    }
}
