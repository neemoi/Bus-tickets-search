using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;
using WebApi.Models;
using AutoMapper;

namespace Application.Services.MappingProfile.Admin
{
    public class MappingRoutes : Profile
    {
        public MappingRoutes()
        {   
            CreateMap<RouteDto, Route>();
            CreateMap<Route, RouteDto>();
            CreateMap<Route, RouteResponseDto>();
        }
    }
}