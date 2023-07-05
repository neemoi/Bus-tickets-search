using WebApi.Models;
using AutoMapper;
using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.MappingProfile.Admin
{
    public class MappingDrivers : Profile
    {
        public MappingDrivers()
        {
            CreateMap<DriverDto, Driver>();
            CreateMap<Driver, DriverResponseDto>();
        }
    }
}