using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;
using WebApi.Models;
using AutoMapper;

namespace Application.Services.MappingProfile.Admin
{
    public class MappingTransports : Profile
    {
        public MappingTransports()
        {   
            CreateMap<TransportDto, Transport>();
            CreateMap<Transport, TransportResponseDto>();
        }
    }
}