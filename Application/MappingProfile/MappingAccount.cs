using WebApi.Models;
using AutoMapper;
using Application.DtoModels.Models.User;
using Application.DtoModels.Response.User;

namespace Application.MappingProfile
{
    public class MappingAccount : Profile
    {
        public MappingAccount()
        {
            //Account
            CreateMap<RegisterDto, User>();
            CreateMap<User, LoginResponseDto>();
            CreateMap<User, RegisterResponseDto>();
            CreateMap<User, LogoutResponseDto>();
        }
    }
}