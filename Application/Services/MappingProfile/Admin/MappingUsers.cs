using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Models.User;
using Application.Services.DtoModels.Response.Admin;
using Application.Services.DtoModels.Response.User;
using WebApi.Models;
using AutoMapper;

namespace Application.Services.MappingProfile.Admin
{
    public class MappingUsers : Profile
    {
        public MappingUsers()
        {
            //AdminUser
            CreateMap<UserDto, User>();
            CreateMap<User, UserResponseDto>();
        }
    }
}