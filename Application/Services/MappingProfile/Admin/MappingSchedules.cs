using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;
using WebApi.Models;
using AutoMapper;

namespace Application.Services.MappingProfile.Admin
{
    public class MappingSchedules : Profile
    {
        public MappingSchedules()
        {   
            CreateMap<string, TimeOnly>()
             .ConvertUsing(src => TimeOnly.Parse(src));
            CreateMap<string, DateOnly>()
             .ConvertUsing(src => DateOnly.Parse(src));

            CreateMap<ScheduleDto, Sсhedule>();
            CreateMap<Sсhedule, ScheduleResponseDto>();
        }
    }
}