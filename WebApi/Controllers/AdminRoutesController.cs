using Application.Services.DtoModels.DtoModels;
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
    }
}
