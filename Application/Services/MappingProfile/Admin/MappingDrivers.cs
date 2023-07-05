using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;
using WebApi.Models;
using AutoMapper;

namespace Application.Services.MappingProfile.Admin
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