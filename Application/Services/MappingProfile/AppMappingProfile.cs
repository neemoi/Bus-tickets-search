using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Models.User;
using Application.Services.DtoModels.Response.Admin;
using Application.Services.DtoModels.Response.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApi.Models;

namespace Application.Services.MappingProfile
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            //Account
            CreateMap<RegisterDto, User>();
            CreateMap<User, LoginResponseDto>();
            CreateMap<User, RegisterResponseDto>();
            CreateMap<User, LogoutResponseDto>();

            //AdminUser
            CreateMap<User, UserDto>();
            CreateMap<User, UserResponseDto>();

            //AdminRoles
            CreateMap<User, RoleResponseDto>();
            CreateMap<IdentityRole, RoleResponseDto>();

            //AdminRoute
            CreateMap<RouteDto, Route>();
            CreateMap<Route, RouteDto>();
            CreateMap<Route, RouteResponseDto>();

            //AdminDriver
            CreateMap<DriverDto, Driver>();
            CreateMap<Driver, DriverResponseDto>();

            //AdminTransport
            CreateMap<TransportDto, Transport>();
            CreateMap<Transport, TransportResponseDto>();

            //AdminSсhedule
            CreateMap<string, TimeOnly>()
             .ConvertUsing(src => TimeOnly.Parse(src));
            CreateMap<string, DateOnly>()
             .ConvertUsing(src => DateOnly.Parse(src));

            CreateMap<ScheduleDto, Sсhedule>();
            CreateMap<Sсhedule, ScheduleResponseDto>();
        }
    }
}
