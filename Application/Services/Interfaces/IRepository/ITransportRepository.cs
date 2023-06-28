using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IRepository
{
    public interface IRepositoryTransport
    {
        Task<TransportResponseDto> CreateTransportAsync(TransportDto model);

        Task<TransportResponseDto> EditTransportAsync(uint idTransport, TransportDto model);

        Task<TransportResponseDto> DeleteTransportByIdAsync(uint idTransport);

        Task<TransportResponseDto> GetByIdTransportAsync(uint idTransport);

        Task<List<TransportResponseDto>> GetAllTransportAsync();
    }
}