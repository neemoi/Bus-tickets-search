using Application.Services.DtoModels.DtoModels.Driver;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    public class DriversController : ControllerBase
    {
        private readonly DriverRepository _controller;

        public DriversController(DriverRepository repository)
        {
            _controller = repository;
        }

        [HttpGet("/api/GetAllDriver")]
        public async Task<IActionResult> GetAllDriverAsync()
        {
            return Ok(await _controller.GetAllDriverAsync());
        }

        [HttpGet("/api/GetByIdDriver")]
        public async Task<IActionResult> GetByIdDriverAsync(uint idDriver)
        {
            return Ok(await _controller.GetByIdDriverAsync(idDriver));
        }

        [HttpPost("/api/CreatNewDriver")]
        public async Task<IActionResult> CreatNewDriverAsync(CreateDriverDto model)
        {
            return Ok(await _controller.CreateDriverAsync(model));
        }

        [HttpPost("/api/EditDriver")]
        public async Task<IActionResult> EditDriverAsync(uint idDriver, EditDriverDto model)
        {
            return Ok(await _controller.EditDriverAsync(idDriver, model));
        }

        [HttpDelete("/api/DeleteDriverById")]
        public async Task<IActionResult> DeleteDriverByIdAsync(uint idDriver)
        {
            return Ok(await _controller.DeleteDriverByIdAsync(idDriver));
        }
    }
}
