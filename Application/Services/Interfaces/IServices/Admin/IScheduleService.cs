using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IScheduleService
    {
        Task<ScheduleResponseDto> CreateSсhedulesAsync(ScheduleDto model);

        Task<ScheduleResponseDto> EditSсhedulesAsync(uint idSсhedule, ScheduleDto model);

        Task<ScheduleResponseDto> DeleteSсhedulesByIdAsync(uint idSсhedule);

        Task<ScheduleResponseDto> GetByIdSсhedulesAsync(uint idSсhedule);

        Task<List<ScheduleResponseDto>> GetAllSсhedulesAsync();
    }
}
