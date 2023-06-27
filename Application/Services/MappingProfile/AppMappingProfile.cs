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
            CreateMap<User, UserLoginResponseDto>();
            CreateMap<User, UserRegisterResponseDto>();
            CreateMap<User, UserLogoutResponseDto>();

            //AdminUser
            CreateMap<User, UserDto>();
            CreateMap<User, AdminUserResponseDto>();

            //AdminRoles
            CreateMap<User, AdminRoleDto>();
            CreateMap<IdentityRole, AdminRoleDto>();

            //AdminRoute
            CreateMap<RouteDto, Route>();
            CreateMap<Route, RouteDto>();
            CreateMap<Route, AdminRouteDto>();

            //AdminDriver
            CreateMap<DriverDto, Driver>();
            CreateMap<Driver, AdminDriverDto>();

            //AdminTransport
            CreateMap<TransportDto, Transport>();
            CreateMap<Transport, AdminTransportDto>();

            //AdminShedule
            CreateMap<string, TimeOnly>()
             .ConvertUsing(src => TimeOnly.Parse(src));
            CreateMap<string, DateOnly>()
             .ConvertUsing(src => DateOnly.Parse(src));

            CreateMap<ScheduleDto, Shedule>();
            CreateMap<Shedule, AdminSheduleDto>();
        }
    }
}
