using Application.Services.DtoModels.Models.User;
using Application.Services.DtoModels.Response.User;
using WebApi.Models;
using AutoMapper;

namespace Application.Services.MappingProfile
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