using Application.DtoModels.Response.User;
using Application.Services.Interfaces.IRepository.User;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.User
{
    public class OrderManagementRepository : IOrderManagementRepository
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public OrderManagementRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<InfoOrderResponseDto> GetInfoByIdTicketAsync(string idUser)
        {
            var ticket = _btsContext.Tickets.Where(u => u.UserId == idUser);


            var currentTicket = _btsContext.Users
             .Include(u => u.Tickets).ThenInclude(t => t.FkRouteTNavigation)
             .Include(u => u.Tickets).ThenInclude(t => t.FkRouteTNavigation).ThenInclude(r => r.FkSheduleNavigation)
             .Include(u => u.Tickets).ThenInclude(t => t.FkRouteTNavigation).ThenInclude(r => r.FkTransportNavigation)
             .Where(u => u.Id == idUser)
             .Select(u => new InfoOrderResponseDto
             {
                 TicketId = u.Tickets.FirstOrDefault().TicketId,
                 Surname = u.Surname,
                 Price = u.Tickets.FirstOrDefault().Price,
                 StartLocation = u.Tickets.FirstOrDefault().FkRouteTNavigation.StartLocation,
                 EndLocation = u.Tickets.FirstOrDefault().FkRouteTNavigation.EndLocation,
                 DepartureTime = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkSheduleNavigation.DepartureTime,
                 ArrivalTime = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkSheduleNavigation.ArrivalTime,
                 Model = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkTransportNavigation.Model,
                 Number = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkTransportNavigation.Number,
                 Color = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkTransportNavigation.Color,
             }).FirstOrDefault();

            if (currentTicket != null)
            {
                return _mapper.Map<InfoOrderResponseDto>(currentTicket);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }

        public async Task<InfoOrderResponseDto> CancelOrderAsync(string idUser)
        {
            var ticket = _btsContext.Tickets
               .Where(t => t.User.Id == idUser)
               .FirstOrDefault();

            if (ticket != null)
            {
                _btsContext.Tickets.Remove(ticket);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<InfoOrderResponseDto>(ticket);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }
    }
}