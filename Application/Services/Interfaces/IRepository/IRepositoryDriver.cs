using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

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
