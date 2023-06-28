using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.Repository
{
    public interface IRouteRepository
    {
        Task<RouteResponseDto> CreatNewRouteAsync(RouteDto model);

        Task<RouteResponseDto> EditRouteAsync(uint idRoute, RouteDto model);

        Task<RouteResponseDto> DeleteRouteAsync(uint idRoute);

        Task<RouteResponseDto> GetByIdRouteAsync(uint idRoute);

        Task<List<RouteResponseDto>> GetAllRouteAsync();
    }
}