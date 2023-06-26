using Application.Services.DtoModels.DtoModels;
using Application.Services.DtoModels.DtoModels.Driver;
using Application.Services.DtoModels.Response.AdminDriverControllerDto;
using Application.Services.DtoModels.Response.AdminRoutesControllerDto;

namespace Application.Services.Interfaces.IRepository
{
    public interface IRepositoryDriver
    {
        Task<AdminCreateNewDriverDto> CreatNewDriverAsync(CreateNewDriverDto model);

        Task<AdminEditDriverDto> EditDriverAsync(EditDriverDto model);

        Task<AdminDeleteDriverDto> DeleteDriverAsync(DeleteDriverDto model);

        Task<AdminGetByIdDriverDto> GetByIdDriverAsync(GetByIdDriverDto model);

        Task<AdminGetAllDriverDto> GetAllDriverAsync(GetAllDriverDto model);

    }
}
