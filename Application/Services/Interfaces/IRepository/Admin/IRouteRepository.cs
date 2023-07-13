using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using WebApi.Models;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IRouteRepository
    {
        Task<Route> CreatNewRoutesAsync(Route route);

        Task<Route> EditRoutesAsync(uint idRoute, RouteDto model);

        Task<Route> DeleteRoutesAsync(uint idRoute);

        Task<Route> GetByIdRoutesAsync(uint idRoute);

        Task<List<Route>> GetAllRoutesAsync();
    }
}