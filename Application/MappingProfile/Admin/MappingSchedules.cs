using WebApi.Models;
using AutoMapper;
using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.MappingProfile.Admin
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