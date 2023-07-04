using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IRouteRepository
    {
        Task<RouteResponseDto> CreatNewRoutesAsync(RouteDto model);

        Task<RouteResponseDto> EditRoutesAsync(uint idRoute, RouteDto model);

        Task<RouteResponseDto> DeleteRoutesAsync(uint idRoute);

        Task<RouteResponseDto> GetByIdRoutesAsync(uint idRoute);

        Task<List<RouteResponseDto>> GetAllRoutesAsync();
    }
}