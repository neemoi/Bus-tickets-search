using WebApi.Models;
using AutoMapper;
using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.MappingProfile.Admin
{
    public class MappingTickets : Profile
    {
        public MappingTickets()
        {
            CreateMap<TicketDto, Ticket>();
            CreateMap<Ticket, TicketResponseDto>();
        }
    }
}