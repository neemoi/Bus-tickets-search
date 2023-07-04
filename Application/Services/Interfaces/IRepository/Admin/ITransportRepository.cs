using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface ITransportRepository
    {
        Task<TransportResponseDto> CreateTransportsAsync(TransportDto model);

        Task<TransportResponseDto> EditTransportsAsync(uint idTransport, TransportDto model);

        Task<TransportResponseDto> DeleteTransportsByIdAsync(uint idTransport);

        Task<TransportResponseDto> GetByIdTransportsAsync(uint idTransport);

        Task<List<TransportResponseDto>> GetAllTransportsAsync();
    }
}