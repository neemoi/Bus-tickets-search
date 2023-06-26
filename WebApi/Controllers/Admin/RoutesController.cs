using Application.Services.DtoModels.DtoModels.Route;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    //[Authorize(Roles = "Admin")]
    public class RoutesController : ControllerBase
    {
        private readonly AdminRoutesRepository _controller;

        public RoutesController(AdminRoutesRepository routesController)
        {
            _controller = routesController;
        }

        [HttpPost("/api/CreatNewRoute")]
        public async Task<IActionResult> CreatNewRouteAsync(CreateRouteDto model)
        {
            return Ok(await _controller.CreatNewRouteAsync(model));
        }


        [HttpDelete("/api/DeleteRoute")]
        public async Task<IActionResult> DeleteRoute(CreateRouteDto model)
        {
            return Ok(await _controller.CreatNewRouteAsync(model));
        }
    }
}
