using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.User;
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

        public async Task<InfoTicketResponseDto> GetInfoTicketAsync(string idUser)
        {
            var currentTicket = _btsContext.Users
                .Where(u => u.Id == idUser)
                .Select(u => new InfoTicketResponseDto
                {
                    TicketId = u.Tickets.FirstOrDefault().TicketId,
                    Surname= u.Surname,
                    Price = u.Tickets.FirstOrDefault().Price,
                    StartLocation = u.Tickets.FirstOrDefault().FkRouteTNavigation.StartLocation,
                    EndLocation = u.Tickets.FirstOrDefault().FkRouteTNavigation.EndLocation,
                    DepartureTime = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkSheduleNavigation.DepartureTime,
                    ArrivalTime = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkSheduleNavigation.ArrivalTime,
                    Model = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkTransportNavigation.Model,
                    Number = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkTransportNavigation.Number,
                    Color = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkTransportNavigation.Color,
                    //Оставляем имя водителя? 
                    //Name = u.Tickets.FirstOrDefault().FkRouteTNavigation.FkDriverNavigation.Name

                }).FirstOrDefault();

            if (currentTicket != null)
            {
                return _mapper.Map<InfoTicketResponseDto>(currentTicket);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }

        public async Task<InfoTicketResponseDto> TicketCancellationAsync(string idUser)
        {
            var ticket = _btsContext.Tickets
               .Where(t => t.User.Id == idUser)
               .FirstOrDefault();

            if (ticket != null)
            {
                _btsContext.Tickets.Remove(ticket);
                
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<InfoTicketResponseDto>(ticket);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Ticket not found");
            }
        }
    }
}
