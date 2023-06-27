using Application.Services.DtoModels.Response;
using Application.Services.DtoModels.DtoModels;
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
            CreateMap<User, UserLoginResponseDto>();

            CreateMap<User, UserRegisterResponseDto>();

            CreateMap<User, UserLogoutResponseDto>();

            //AdminUser
            CreateMap<User, AdminUserResponseDto>();

            //AdminRoles
            CreateMap<IdentityRole, AdminRoleDto>();

            //AdminRoute
            CreateMap<Route, AdminRouteDto>();

            //AdminDriver
            CreateMap<Driver, AdminDriverDto>();
         
            //AdminTransport
            CreateMap<Transport, AdminTransportDto>();

            //AdminShedule
            CreateMap<Shedule, AdminSheduleDto>();
        }
    }
}
