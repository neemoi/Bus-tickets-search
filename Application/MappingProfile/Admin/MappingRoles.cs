using Microsoft.AspNetCore.Identity;
using WebApi.Models;
using AutoMapper;
using Application.DtoModels.Response.Admin;

namespace Application.MappingProfile.Admin
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