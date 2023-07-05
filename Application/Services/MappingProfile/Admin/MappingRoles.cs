using Application.Services.DtoModels.Response.Admin;
using Microsoft.AspNetCore.Identity;
using WebApi.Models;
using AutoMapper;

namespace Application.Services.MappingProfile.Admin
{
    public class MappingRoles : Profile
    {
        public MappingRoles()
        {   
            CreateMap<RoleResponseDto, User>();
            CreateMap<IdentityRole, RoleResponseDto>();
        }
    }
}