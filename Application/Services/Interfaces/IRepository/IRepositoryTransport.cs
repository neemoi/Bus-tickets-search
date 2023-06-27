using Application.Services.DtoModels.DtoModels;
using Application.Services.DtoModels.Response;

namespace Application.Services.Interfaces.IRepository
{
    public interface IRepositoryTransport
    {
        Task<AdminTransportDto> CreateTransportAsync(TransportDto model);

        Task<AdminTransportDto> EditTransportAsync(uint idTransport, TransportDto model);

        Task<AdminTransportDto> DeleteTransportByIdAsync(uint idTransport);

        Task<AdminTransportDto> GetByIdTransportAsync(uint idTransport);

        Task<List<AdminTransportDto>> GetAllTransportAsync();
    }
}
