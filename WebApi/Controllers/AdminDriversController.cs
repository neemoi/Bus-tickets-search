using Application.Services.DtoModels.DtoModels.Driver;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository;

namespace WebApi.Controllers
{
    public class AdminDriversController : ControllerBase
    {
        private readonly AdminDriversRepository _controller;

        public AdminDriversController(AdminDriversRepository repository)
        {
            _controller = repository;
        }

        [HttpPost("/api/CreatNewDriver")]
        public async Task<IActionResult> CreatNewDriverAsync(CreateNewDriverDto model)
        {
            var result = await _controller.CreatNewDriverAsync(model);

            return Ok(result);
        }
    }
}
