using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using WebApi.Models;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IDriverRepository
    {
        Task<Driver> CreateDriverAsync(Driver driver);

        Task<Driver> EditDriversAsync(uint idDriver, DriverDto model);

        Task<Driver> DeleteDriversByIdAsync(uint idDriver);

        Task<Driver> GetByIdDriversAsync(uint idDriver);

        Task<List<Driver>> GetAllDriversAsync();
    }
}