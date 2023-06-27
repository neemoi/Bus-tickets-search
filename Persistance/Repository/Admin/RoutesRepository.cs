using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;
using Application.Services.Interfaces.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.Admin
{
    public class RoutesRepository : IRepositoryRoute
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public RoutesRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<AdminRouteDto> CreatNewRouteAsync(RouteDto model)
        {
            var route = _mapper.Map<Route>(model);

            var result = await _btsContext.Routes.AddAsync(route);

            if (result != null && route != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminRouteDto>(route);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route note found");
            }
        }

        public async Task<AdminRouteDto> DeleteRouteAsync(uint idRoute)
        {
            var result = await _btsContext.Routes.FirstOrDefaultAsync(r => r.RouteId == idRoute);

            if (result != null)
            {
                _btsContext.Routes.Remove(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminRouteDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route note found");
            }
        }

        public async Task<AdminRouteDto> EditRouteAsync(uint idRoute, RouteDto model)
        {
            var result = await _btsContext.Routes.FirstOrDefaultAsync(r => r.RouteId == idRoute);

            if (result != null)
            {
                _mapper.Map(model, result);

                _btsContext.Routes.Update(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminRouteDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route note found");
            }
        }

        public async Task<List<AdminRouteDto>> GetAllRouteAsync()
        {
            var result = await _btsContext.Routes.ToListAsync();

            if (result != null)
            {
                var mappedShedules = new List<AdminRouteDto>();

                foreach (var shedule in result)
                {
                    var mappedShedule = _mapper.Map<AdminRouteDto>(shedule);

                    mappedShedules.Add(mappedShedule);
                }

                return mappedShedules;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route note found");
            }
        }

        public async Task<AdminRouteDto> GetByIdRouteAsync(uint idRoute)
        {
            var result = await _btsContext.Routes.FirstOrDefaultAsync(s => s.RouteId == idRoute);

            if (result != null)
            {
                return _mapper.Map<AdminRouteDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route note found");
            }
        }
    }
}
