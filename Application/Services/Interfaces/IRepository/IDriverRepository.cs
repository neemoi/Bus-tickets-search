using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IRepository
{
    public interface IDriverRepository
    {
        Task<DriverResponseDto> CreateDriverAsync(DriverDto model);

        Task<DriverResponseDto> EditDriverAsync(uint idDriver, DriverDto model);

        Task<DriverResponseDto> DeleteDriverByIdAsync(uint idDriver);

        Task<DriverResponseDto> GetByIdDriverAsync(uint idDriver);

        Task<List<DriverResponseDto>> GetAllDriverAsync();
    }
}