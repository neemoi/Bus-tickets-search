using Application.Services.DtoModels.DtoModels.Driver;
using Application.Services.DtoModels.Response.AdminDriverControllerDto;

namespace Application.Services.Interfaces.IRepository
{
    public interface IRepositoryDriver
    {
        Task<AdminCreateDriverDto> CreateDriverAsync(CreateDriverDto model);

        Task<AdminEditDriverDto> EditDriverAsync(uint idDriver, EditDriverDto model);

        Task<AdminDeleteDriverById> DeleteDriverByIdAsync(uint idDriver);

        Task<AdminGetByIdDriverDto> GetByIdDriverAsync(uint idDriver);

        Task<List<AdminGetAllDriverDto>> GetAllDriverAsync();
    }
}
