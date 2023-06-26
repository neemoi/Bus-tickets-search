using Application.Services.DtoModels.DtoModels.Route;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository;

namespace WebApi.Controllers
{
    public class AdminRoutesController : ControllerBase
    {
        private readonly AdminRoutesRepository _controller;

        public AdminRoutesController(AdminRoutesRepository routesController)
        {
            _controller = routesController;
        }

        [HttpPost("/api/CreatNewRoute")]
        public async Task<IActionResult> CreatNewRouteAsync(CreateRouteDto model)
        {
            var result = await _controller.CreatNewRouteAsync(model);

            return Ok(result);
        }


        [HttpDelete("/api/DeleteRoute")]
        public async Task<IActionResult> DeleteRoute(CreateRouteDto model)
        {
            var result = await _controller.CreatNewRouteAsync(model);

            return Ok(result);
        }
    }
}
