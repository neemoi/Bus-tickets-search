using Application.Services.DtoModels.DtoModels;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    //[Authorize(Roles = "Admin")]
    public class RoutesController : ControllerBase
    {
        private readonly RoutesRepository _controller;

        public RoutesController(RoutesRepository routesController)
        {
            _controller = routesController;
        }

        [HttpGet("api/Routes")]
        public async Task<IActionResult> GetAllRouteAsync()
        {
            return Ok(await _controller.GetAllRouteAsync());
        }

        [HttpGet("api/Route/{id}")]
        public async Task<IActionResult> GetByIdRouteAsync(uint id)
        {
            return Ok(await _controller.GetByIdRouteAsync(id));
        }

        [HttpPost("api/Routes")]
        public async Task<IActionResult> CreatNewRouteAsync([FromQuery]RouteDto model)
        {
            return Ok(await _controller.CreatNewRouteAsync(model));
        }

        [HttpPut("api/Route{id}")]
        public async Task<IActionResult> EditRouteAsync(uint id, RouteDto model)
        {
            return Ok(await _controller.EditRouteAsync(id, model));
        }

        [HttpDelete("api/Route{id}")]
        public async Task<IActionResult> DeleteRoute(uint id)
        {
            return Ok(await _controller.DeleteRouteAsync(id));
        }
    }
}
