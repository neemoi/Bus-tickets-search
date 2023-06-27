using Application.Services.DtoModels.DtoModels.Route;
using Application.Services.DtoModels.Response.AdminRoutesControllerDto;

namespace Application.Services.Interfaces.Repository
{
    public interface IRepositoryRoute
    {
        Task<CreatNewRouteDto> CreatNewRouteAsync(CreateRouteDto model);

        Task<EdtitRoutesDto> EditRouteAsync(uint idRoute, EditRoutesDto model);

        Task<DeleteRouteDto> DeleteRouteAsync(uint idRoute);

        Task<GetByIdRoutesDto> GetByIdRouteAsync(uint idRoute);

        Task<List<GetAllRouteDto>> GetAllRouteAsync();
    }
}
