using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IDriverRepository
    {
        Task<DriverResponseDto> CreateDriverAsync(DriverDto model);

        Task<DriverResponseDto> EditDriversAsync(uint idDriver, DriverDto model);

        Task<DriverResponseDto> DeleteDriversByIdAsync(uint idDriver);

        Task<DriverResponseDto> GetByIdDriversAsync(uint idDriver);

        Task<List<DriverResponseDto>> GetAllDriversAsync();
    }
}