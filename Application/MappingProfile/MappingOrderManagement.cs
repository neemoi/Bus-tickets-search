using WebApi.Models;
using AutoMapper;
using Application.DtoModels.Response.User;

namespace Application.MappingProfile
{
    public class MappingOrderManagement : Profile
    {
        public MappingOrderManagement()
        {
            //OrderManagment
            CreateMap<Ticket, InfoOrderResponseDto>();
        }
    }
}