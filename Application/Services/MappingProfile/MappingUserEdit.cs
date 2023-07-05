using Application.Services.DtoModels.Models.User;
using Application.Services.DtoModels.Response.User;
using WebApi.Models;
using AutoMapper;

namespace Application.Services.MappingProfile
{
    public class MappingUserEdit : Profile
    {
        public MappingUserEdit()
        {
            //UserEdit
            CreateMap<EditProfileDto, User>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, EditProfileResposneDto>();
        }
    }
}