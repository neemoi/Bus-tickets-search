using Application.Services.DtoModels.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class TransportsController : ControllerBase
    {
        private readonly TransportRepository _controller;

        public TransportsController(TransportRepository repository)
        {
            _controller = repository;
        }

        [HttpGet("api/Transport")]
        public async Task<IActionResult> GetAllTransportAsync()
        {
            return Ok(await _controller.GetAllTransportAsync());
        }

        [HttpGet("api/Transport/{id}")]
        public async Task<IActionResult> GetByIdTransportAsync(uint id)
        {
            return Ok(await _controller.GetByIdTransportAsync(id));
        }

        [HttpPost("api/Transport")]
        public async Task<IActionResult> CreateTransportAsync([FromBody]TransportDto model)
        {
            return Ok(await _controller.CreateTransportAsync(model));
        }

        [HttpPut("api/EditTransport/{id}")]
        public async Task<IActionResult> EditTransportAsync(uint id, [FromBody]TransportDto model)
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