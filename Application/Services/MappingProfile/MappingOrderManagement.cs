using Application.Services.DtoModels.Response.User;
using WebApi.Models;
using AutoMapper;

namespace Application.Services.MappingProfile
{
    public class MappingOrderManagement : Profile
    {
        public MappingOrderManagement()
        {   
            //OrderManagment
            CreateMap<Ticket, InfoTicketResponseDto>();
        }
    }
}