using Application.Services.DtoModels.DtoModels;
using Application.Services.DtoModels.Response;

namespace Application.Services.Interfaces.IRepository
{
    public interface IRepositoryShedule
    {
        Task<AdminSheduleDto> CreateSheduleAsync(ScheduleDto model);

        Task<AdminSheduleDto> EditSheduleAsync(uint idShedule, ScheduleDto model);

        Task<AdminSheduleDto> DeleteSheduleByIdAsync(uint idShedule);

        Task<AdminSheduleDto> GetByIdSheduleAsync(uint idShedule);

        Task<List<AdminSheduleDto>> GetAllSheduleAsync();
    }
}
