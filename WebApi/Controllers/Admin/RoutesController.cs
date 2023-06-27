using Application.Services.DtoModels.DtoModels.Route;
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

        [HttpGet("/api/GetAllRoute")]
        public async Task<IActionResult> GetAllRouteAsync()
        {
            return Ok(await _controller.GetAllRouteAsync());
        }

        [HttpGet("/api/GetByIdRoute")]
        public async Task<IActionResult> GetByIdRouteAsync(uint idRoute)
        {
            return Ok(await _controller.GetByIdRouteAsync(idRoute));
        }

        [HttpPost("/api/CreatNewRoute")]
        public async Task<IActionResult> CreatNewRouteAsync(CreateRouteDto model)
        {
            return Ok(await _controller.CreatNewRouteAsync(model));
        }

        [HttpPost("/api/EditRoute")]
        public async Task<IActionResult> EditRouteAsync(uint idRoute, EditRoutesDto model)
        {
            return Ok(await _controller.EditRouteAsync(idRoute, model));
        }

        [HttpDelete("/api/DeleteRoute")]
        public async Task<IActionResult> DeleteRoute(uint idRoute)
        {
            return Ok(await _controller.DeleteRouteAsync(idRoute));
        }
    }
}
