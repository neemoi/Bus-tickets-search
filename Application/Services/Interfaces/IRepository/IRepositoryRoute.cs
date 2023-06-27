using Application.Services.DtoModels.DtoModels;
using Application.Services.DtoModels.Response;

namespace Application.Services.Interfaces.Repository
{
    public interface IRepositoryRoute
    {
        Task<AdminRouteDto> CreatNewRouteAsync(RouteDto model);

        Task<AdminRouteDto> EditRouteAsync(uint idRoute, RouteDto model);

        Task<AdminRouteDto> DeleteRouteAsync(uint idRoute);

        Task<AdminRouteDto> GetByIdRouteAsync(uint idRoute);

        Task<List<AdminRouteDto>> GetAllRouteAsync();
    }
}
