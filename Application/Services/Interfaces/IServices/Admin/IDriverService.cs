using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IDriverService 
    {
        Task<DriverResponseDto> CreateDriverAsync(DriverDto model);

        Task<DriverResponseDto> DeleteDriversByIdAsync(uint idDriver);

        Task<DriverResponseDto> EditDriversAsync(uint idDriver, DriverDto model);

        Task<List<DriverResponseDto>> GetAllDriversAsync();

        Task<DriverResponseDto> GetByIdDriversAsync(uint idDriver);
    }
}
