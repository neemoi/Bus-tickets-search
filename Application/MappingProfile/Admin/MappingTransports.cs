using WebApi.Models;
using AutoMapper;
using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.MappingProfile.Admin
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