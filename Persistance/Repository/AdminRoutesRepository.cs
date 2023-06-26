using Application.Services.DtoModels.DtoModels;
using Application.Services.DtoModels.Response.AdminRoutesControllerDto;
using Application.Services.Interfaces.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository
{
    public class AdminRoutesRepository : IRepositoryRoute
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public AdminRoutesRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<AdminCreatiNewRouteDto> CreatNewRouteAsync(CreateRouteDto model)
        {
            var route = new Route
            {
                StartLocation = model.StartLocation,
                EndLocation = model.EndLocation,
                Distance = model.Distance
            };

            var result = await _btsContext.Routes.AddAsync(route);

            if (result != null && route != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminCreatiNewRouteDto>(route);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Route note found");
            }
        }

        public Task<Route> DeleteRouteAsync(Route route)
        {
            throw new NotImplementedException();
        }

        public Task<Route> EditRouteAsync(Route route)
        {
            throw new NotImplementedException();
        }
    }
}
