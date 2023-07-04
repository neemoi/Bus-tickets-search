using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface ISсheduleRepository
    {
        Task<ScheduleResponseDto> CreateSсhedulesAsync(ScheduleDto model);

        Task<ScheduleResponseDto> EditSсhedulesAsync(uint idSсhedule, ScheduleDto model);

        Task<ScheduleResponseDto> DeleteSсhedulesByIdAsync(uint idSсhedule);

        Task<ScheduleResponseDto> GetByIdSсhedulesAsync(uint idSсhedule);

        Task<List<ScheduleResponseDto>> GetAllSсhedulesAsync();
    }
}