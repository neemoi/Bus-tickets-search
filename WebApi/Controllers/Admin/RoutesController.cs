using Application.DtoModels.Models.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("api/Route")]
        public async Task<IActionResult> GetAllRouteAsync()
        {
            return Ok(await _routeService.GetAllRoutesAsync());
        }

        [HttpGet("api/Route/{id}")]
        public async Task<IActionResult> GetByIdRouteAsync(uint id)
        {
            return Ok(await _routeService.GetByIdRoutesAsync(id));
        }

        [HttpPost("api/Route")]
        public async Task<IActionResult> CreatNewRouteAsync([FromQuery] RouteDto model)
        {
            return Ok(await _routeService.CreatNewRoutesAsync(model));
        }

        [HttpPut("api/Route/{id}")]
        public async Task<IActionResult> EditRouteAsync(uint id, RouteDto model)
        {
            return Ok(await _routeService.EditRoutesAsync(id, model));
        }

        [HttpDelete("api/Route/{id}")]
        public async Task<IActionResult> DeleteRoute(uint id)
        {
            return Ok(await _routeService.DeleteRoutesAsync(id));
        }
    }
}