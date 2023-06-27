using Application.Services.DtoModels.DtoModels.Transport;
using Application.Services.DtoModels.Response.AdminTransportControllerDto;

namespace Application.Services.Interfaces.IRepository
{
    public interface IRepositoryTransport
    {
        Task<AdminCreateTransportDto> CreateTransportAsync(CreateTransportDto model);

        Task<AdminEditTransportDto> EditTransportAsync(uint idTransport, EditTransportDto model);

        Task<AdminDeleteTransportByIdDto> DeleteTransportByIdAsync(uint idTransport);

        Task<AdminGetByIdTransportDto> GetByIdTransportAsync(uint idTransport);

        Task<List<AdminGetAllTransportDto>> GetAllTransportAsync();
    }
}
