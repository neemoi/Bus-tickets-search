using Application.Services.DtoModels.DtoModels.Route;
using Application.Services.DtoModels.Response.AdminRoutesControllerDto;
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

        public async Task<CreatNewRouteDto> CreatNewRouteAsync(CreateRouteDto model)
        {
            var route = new Route
            {
                StartLocation = model.StartLocation,
                EndLocation = model.EndLocation,
                Distance = model.Distance,
                FkDriver = model.FkDriver,
                FkShedule = model.FkShedule,
                FkTransport = model.FkTransport
            };

            var result = await _btsContext.Routes.AddAsync(route);

            if (result != null && route != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<CreatNewRouteDto>(route);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route note found");
            }
        }

        public async Task<DeleteRouteDto> DeleteRouteAsync(uint idRoute)
        {
            var result = await _btsContext.Routes.FirstOrDefaultAsync(r => r.RouteId == idRoute);

            if (result != null)
            {
                _btsContext.Routes.Remove(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<DeleteRouteDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route note found");
            }
        }

        public async Task<EdtitRoutesDto> EditRouteAsync(uint idRoute, EditRoutesDto model)
        {
            var result = await _btsContext.Routes.FirstOrDefaultAsync(r => r.RouteId == idRoute);

            if (result != null)
            {
                result.StartLocation = model.StartLocation;
                result.EndLocation = model.EndLocation;
                result.Distance = model.Distance;
                result.FkDriver = model.FkDriver;
                result.FkTransport = model.FkTransport;
                result.FkShedule = model.FkShedule;

                _btsContext.Routes.Update(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<EdtitRoutesDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route note found");
            }
        }

        public async Task<List<GetAllRouteDto>> GetAllRouteAsync()
        {
            var result = await _btsContext.Shedules.ToListAsync();

            if (result != null)
            {
                var mappedShedules = new List<GetAllRouteDto>();

                foreach (var shedule in result)
                {
                    var mappedShedule = _mapper.Map<GetAllRouteDto>(shedule);

                    mappedShedules.Add(mappedShedule);
                }

                return mappedShedules;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route note found");
            }
        }

        public async Task<GetByIdRoutesDto> GetByIdRouteAsync(uint idRoute)
        {
            var result = await _btsContext.Shedules.FirstOrDefaultAsync(s => s.SheduleId == idRoute);

            if (result != null)
            {
                return _mapper.Map<GetByIdRoutesDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Route note found");
            }
        }
    }
}
