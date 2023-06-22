using Application.Services.DtoModels.Response.AccountController;
using Application.Services.DtoModels.Response.AdminControllerDto;
using Application.Services.DtoModels.Response.AdminRolesControllerDto;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApi.Models;

namespace Application.Services.MappingProfile
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            //AccountController
            CreateMap<User, UserLoginResponseDto>();

            CreateMap<User, UserRegisterResponseDto>();

            CreateMap<User, UserLogoutResponseDto>();

            //AdminUserController
            CreateMap<User, AdminUserDeleteUserResponseDto>();

            CreateMap<User, AdminUserEditUserResponseDto>();

            CreateMap<User, AdminUserGetAllUsersResponseDto>();

            CreateMap<User, AdminUserGetByIdUsersResponseDto>();

            //AdminRolesController
            CreateMap<IdentityRole, AdminRolesCreateRoleDto>();

            CreateMap<IdentityRole, AdminRolesDeleteRoleDto>();

            CreateMap<IdentityRole, AdminRolesGetAllRolesDto>();

            CreateMap<IdentityRole, AdminRolesAssignUserRoleDto>();
        }
    }
}
