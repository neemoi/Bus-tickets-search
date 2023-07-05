using Application.DtoModels.Models.Admin;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.Admin
{
    public class RouteRepository : IRouteRepository
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public RouteRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<Route> CreatNewRoutesAsync(Route route)
        {
            var result = await _btsContext.Routes.AddAsync(route);

            if (result != null)
            {
                await _btsContext.SaveChangesAsync();

                return route;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route not found");
            }
        }

        public async Task<Route> DeleteRoutesAsync(uint idRoute)
        {
            var result = await _btsContext.Routes.FirstOrDefaultAsync(r => r.RouteId == idRoute);

            if (result != null)
            {
                _btsContext.Routes.Remove(result);

                await _btsContext.SaveChangesAsync();

                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route not found");
            }
        }

        public async Task<Route> EditRoutesAsync(uint idRoute, RouteDto model)
        {
            var route = await _btsContext.Routes.FirstOrDefaultAsync(r => r.RouteId == idRoute);

            if (route != null)
            {
                _mapper.Map(model, route);

                _btsContext.Routes.Update(route);

                await _btsContext.SaveChangesAsync();

                return route;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route not found");
            }
        }

        public async Task<List<Route>> GetAllRoutesAsync()
        {
            var result = await _btsContext.Routes.ToListAsync();

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route not found");
            }
        }

        public async Task<Route> GetByIdRoutesAsync(uint idRoute)
        {
            var result = await _btsContext.Routes.FirstOrDefaultAsync(s => s.RouteId == idRoute);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route not found");
            }
        }
    }
}