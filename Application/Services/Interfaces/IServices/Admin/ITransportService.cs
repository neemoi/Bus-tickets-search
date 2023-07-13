using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface ITransportService
    {
        Task<TransportResponseDto> CreateTransportsAsync(TransportDto model);

        Task<TransportResponseDto> EditTransportsAsync(uint idTransport, TransportDto model);

        Task<TransportResponseDto> DeleteTransportsByIdAsync(uint idTransport);

        Task<TransportResponseDto> GetByIdTransportsAsync(uint idTransport);

        Task<List<TransportResponseDto>> GetAllTransportsAsync();
    }
}
