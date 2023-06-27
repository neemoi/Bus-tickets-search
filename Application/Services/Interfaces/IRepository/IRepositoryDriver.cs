using Application.Services.DtoModels.DtoModels;
using Application.Services.DtoModels.Response;

namespace Application.Services.Interfaces.IRepository
{
    public interface IRepositoryDriver
    {
        Task<AdminDriverDto> CreateDriverAsync(DriverDto model);

        Task<AdminDriverDto> EditDriverAsync(uint idDriver, DriverDto model);

        Task<AdminDriverDto> DeleteDriverByIdAsync(uint idDriver);

        Task<AdminDriverDto> GetByIdDriverAsync(uint idDriver);

        Task<List<AdminDriverDto>> GetAllDriverAsync();
    }
}
