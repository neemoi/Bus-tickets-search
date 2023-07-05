using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;
using WebApi.Models;
using AutoMapper;

namespace Application.Services.MappingProfile.Admin
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