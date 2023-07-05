using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using AutoMapper;
using WebApi.Models;

namespace Application.Services.Implementations.Admin
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RouteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RouteResponseDto> CreatNewRoutesAsync(RouteDto model)
        {
            var route = _mapper.Map<Route>(model);

            var result = await _unitOfWork.RouteRepository.CreatNewRoutesAsync(route);

            return _mapper.Map<RouteResponseDto>(result);
        }

        public async Task<RouteResponseDto> DeleteRoutesAsync(uint idRoute)
        {
            var result = await _unitOfWork.RouteRepository.DeleteRoutesAsync(idRoute);

            return _mapper.Map<RouteResponseDto>(result);
        }

        public async Task<RouteResponseDto> EditRoutesAsync(uint idRoute, RouteDto model)
        {
            var result = await _unitOfWork.RouteRepository.EditRoutesAsync(idRoute, model);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<RouteResponseDto>(result);
        }

        public async Task<List<RouteResponseDto>> GetAllRoutesAsync()
        {
            var result = await _unitOfWork.RouteRepository.GetAllRoutesAsync();

            var mappedRoutes = new List<RouteResponseDto>();

            foreach (var route in result)
            {
                var mappedRoute = _mapper.Map<RouteResponseDto>(route);

                mappedRoutes.Add(mappedRoute);
            }

            return mappedRoutes;
        }

        public async Task<RouteResponseDto> GetByIdRoutesAsync(uint idRoute)
        {
            var result = await _unitOfWork.RouteRepository.GetByIdRoutesAsync(idRoute);

            return _mapper.Map<RouteResponseDto>(result);
        }
    }
}
