using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using WebApi.Models;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface ITransportRepository
    {
        Task<Transport> CreateTransportsAsync(Transport transport);

        Task<Transport> EditTransportsAsync(uint idTransport, TransportDto model);

        Task<Transport> DeleteTransportsByIdAsync(uint idTransport);

        Task<Transport> GetByIdTransportsAsync(uint idTransport);

        Task<List<Transport>> GetAllTransportsAsync();
    }
}