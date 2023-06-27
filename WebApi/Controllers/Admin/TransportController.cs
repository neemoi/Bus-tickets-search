using Application.Services.DtoModels.DtoModels;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    public class TransportController : ControllerBase
    {
        private readonly TransportRepository _controller;

        public TransportController(TransportRepository repository)
        {
            _controller = repository;
        }

        [HttpGet("api/Transports")]
        public async Task<IActionResult> GetAllTransportAsync()
        {
            return Ok(await _controller.GetAllTransportAsync());
        }

        [HttpGet("api/Transport/{id}")]
        public async Task<IActionResult> GetByIdTransportAsync(uint id)
        {
            return Ok(await _controller.GetByIdTransportAsync(id));
        }

        [HttpPost("api/Transports")]
        public async Task<IActionResult> CreateTransportAsync([FromQuery]TransportDto model)
        {
            return Ok(await _controller.CreateTransportAsync(model));
        }

        //не пашет бедалага
        [HttpPut("api/EditTransport/{id}")]
        public async Task<IActionResult> EditTransportAsync(uint id, TransportDto model)
        {
            return Ok(await _controller.EditTransportAsync(id, model));
        }

        [HttpDelete("api/Transport/{id}")]
        public async Task<IActionResult> DeleteTransportByIdAsync(uint id)
        {
            return Ok(await _controller.DeleteTransportByIdAsync(id));
        }
    }
}
