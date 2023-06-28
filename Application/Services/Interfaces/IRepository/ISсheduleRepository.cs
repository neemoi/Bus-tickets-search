using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IRepository
{
    public interface ISсheduleRepository
    {
        Task<ScheduleResponseDto> CreateSсheduleAsync(ScheduleDto model);

        Task<ScheduleResponseDto> EditSсheduleAsync(uint idSсhedule, ScheduleDto model);

        Task<ScheduleResponseDto> DeleteSсheduleByIdAsync(uint idSсhedule);

        Task<ScheduleResponseDto> GetByIdSсheduleAsync(uint idSсhedule);

        Task<List<ScheduleResponseDto>> GetAllSсheduleAsync();
    }
}