using Application.Services.DtoModels.Models.Admin;
using Application.Services.Interfaces.IRepository.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteRepository _routeRepository;

        public RoutesController(RouteRepository routesController)
        {
            _routeRepository = routesController;
        }

        [HttpGet("api/Route")]
        public async Task<IActionResult> GetAllRouteAsync()
        {
            return Ok(await _routeRepository.GetAllRoutesAsync());
        }

        [HttpGet("api/Route/{id}")]
        public async Task<IActionResult> GetByIdRouteAsync(uint id)
        {
            return Ok(await _routeRepository.GetByIdRoutesAsync(id));
        }

        [HttpPost("api/Route")]
        public async Task<IActionResult> CreatNewRouteAsync([FromQuery]RouteDto model)
        {
            return Ok(await _routeRepository.CreatNewRoutesAsync(model));
        }

        [HttpPut("api/Route/{id}")]
        public async Task<IActionResult> EditRouteAsync(uint id, RouteDto model)
        {
            return Ok(await _routeRepository.EditRoutesAsync(id, model));
        }

        [HttpDelete("api/Route/{id}")]
        public async Task<IActionResult> DeleteRoute(uint id)
        {
            return Ok(await _routeRepository.DeleteRoutesAsync(id));
        }
    }
}