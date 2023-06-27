using Application.Services.DtoModels.DtoModels.Shedule;
using Application.Services.DtoModels.Response.AdminSheduleControllerDto;

namespace Application.Services.Interfaces.IRepository
{
    public interface IRepositoryShedule
    {
        Task<AdminCreateSheduleDto> CreateSheduleAsync(CreateSheduleDto model);

        Task<AdminEditSheduleDto> EditSheduleAsync(uint idShedule, EditSheduleDto model);

        Task<AdminDeleteSheduleByIdDto> DeleteSheduleByIdAsync(uint idShedule);

        Task<AdminGetByIdSheduleDto> GetByIdSheduleAsync(uint idShedule);

        Task<List<AdminGetAllSheduleDto>> GetAllSheduleAsync();
    }
}
