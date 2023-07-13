using WebApi.Models;
using AutoMapper;
using Application.DtoModels.Models.User;
using Application.DtoModels.Response.User;

namespace Application.MappingProfile
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