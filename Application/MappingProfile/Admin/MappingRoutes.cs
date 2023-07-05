using WebApi.Models;
using AutoMapper;
using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.MappingProfile.Admin
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