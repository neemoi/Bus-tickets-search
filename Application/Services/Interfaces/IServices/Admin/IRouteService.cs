using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IRouteService
    {
        Task<RouteResponseDto> CreatNewRoutesAsync(RouteDto model);

        Task<RouteResponseDto> EditRoutesAsync(uint idRoute, RouteDto model);

        Task<RouteResponseDto> DeleteRoutesAsync(uint idRoute);

        Task<RouteResponseDto> GetByIdRoutesAsync(uint idRoute);

        Task<List<RouteResponseDto>> GetAllRoutesAsync();
    }
}
