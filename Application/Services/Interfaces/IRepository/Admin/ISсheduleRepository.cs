using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using WebApi.Models;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface ISсheduleRepository
    {
        Task<Sсhedule> CreateSсhedulesAsync(Sсhedule sсhedule);

        Task<Sсhedule> EditSсhedulesAsync(uint idSсhedule, ScheduleDto model);

        Task<Sсhedule> DeleteSсhedulesByIdAsync(uint idSсhedule);

        Task<Sсhedule> GetByIdSсhedulesAsync(uint idSсhedule);

        Task<List<Sсhedule>> GetAllSсhedulesAsync();
    }
}