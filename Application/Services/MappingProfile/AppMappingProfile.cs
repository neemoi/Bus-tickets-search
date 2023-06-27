using Application.Services.DtoModels.Response.AccountController;
using Application.Services.DtoModels.Response.AdminControllerDto;
using Application.Services.DtoModels.Response.AdminDriverControllerDto;
using Application.Services.DtoModels.Response.AdminRolesControllerDto;
using Application.Services.DtoModels.Response.AdminRoutesControllerDto;
using Application.Services.DtoModels.Response.AdminSheduleControllerDto;
using Application.Services.DtoModels.Response.AdminTransportControllerDto;
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
            CreateMap<User, AdminUserDeleteUserResponseDto>();

            CreateMap<User, AdminUserEditUserResponseDto>();

            CreateMap<User, AdminUserGetAllUsersResponseDto>();

            CreateMap<User, AdminUserGetByIdUsersResponseDto>();

            //AdminRoles
            CreateMap<IdentityRole, AdminRolesCreateRoleDto>();

            CreateMap<IdentityRole, AdminRolesDeleteRoleDto>();

            CreateMap<IdentityRole, AdminRolesGetAllRolesDto>();

            CreateMap<IdentityRole, AdminRolesAssignUserRoleDto>();

            //AdminRoute
            CreateMap<Route, CreatNewRouteDto>();

            CreateMap<Route, DeleteRouteDto>();

            CreateMap<Route, EdtitRoutesDto>();
            
            CreateMap<Route, GetByIdRoutesDto>();
            
            CreateMap<Route, GetAllRouteDto>();

            //AdminDriver
            CreateMap<Driver, AdminCreateDriverDto>();
         
            CreateMap<Driver, AdminDeleteDriverById>();

            CreateMap<Driver, AdminGetAllDriverDto>();

            CreateMap<Driver, AdminGetByIdDriverDto>();

            CreateMap<Driver, AdminEditDriverDto>();

            //AdminTransport
            CreateMap<Transport, AdminCreateTransportDto>();

            CreateMap<Transport, AdminGetAllTransportDto>();

            CreateMap<Transport, AdminGetByIdTransportDto>();

            CreateMap<Transport, AdminEditTransportDto>();

            CreateMap<Transport, AdminDeleteTransportByIdDto>();

            //AdminShedule
            CreateMap<Shedule, AdminCreateSheduleDto>();
            
            CreateMap<Shedule, AdminGetAllSheduleDto>();

            CreateMap<Shedule, AdminGetByIdSheduleDto>();

            CreateMap<Shedule, AdminDeleteSheduleByIdDto>();

            CreateMap<Shedule, AdminEditSheduleDto>();
        }
    }
}
