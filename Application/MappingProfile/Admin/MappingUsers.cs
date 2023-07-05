using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using AutoMapper;
using WebApi.Models;

namespace Application.MappingProfile.Admin
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