using Application.Services.DtoModels.DtoModels;
using Application.Services.DtoModels.Response.AdminRoutesControllerDto;
using WebApi.Models;

namespace Application.Services.Interfaces.Repository
{
    public interface IRepositoryRoute
    {
        Task<AdminCreatiNewRouteDto> CreatNewRouteAsync(CreateRouteDto model);

        Task<Route> EditRouteAsync(Route route);

        Task<Route> DeleteRouteAsync(Route route);
    }
}
