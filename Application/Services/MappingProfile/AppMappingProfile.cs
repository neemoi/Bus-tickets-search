using Application.Services.DtoModels.Response.AccountController;
using Application.Services.DtoModels.Response.AdminControllerDto;
using Application.Services.DtoModels.Response.AdminRolesControllerDto;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApi.Models;

namespace Application.Services.MappingProfile
{
    //может разделить на разные классы? 
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            //AccountController
            CreateMap<User, UserLoginResponceDto>();

            CreateMap<User, UserRegisterResponceDto>();

            CreateMap<User, UserRegisterResponceDto>();

            //AdminUserController
            CreateMap<User, AdminUserDeleteUserResponceDto>();

            CreateMap<User, AdminUserEditUserResponceDto>();

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
