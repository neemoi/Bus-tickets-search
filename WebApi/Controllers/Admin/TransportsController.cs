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
            return Ok(await _controller.GetAllTransportsAsync());
        }

        [HttpGet("api/Transport/{id}")]
        public async Task<IActionResult> GetByIdTransportAsync(uint id)
        {
            return Ok(await _controller.GetByIdTransportsAsync(id));
        }

        [HttpPost("api/Transport")]
        public async Task<IActionResult> CreateTransportAsync([FromBody]TransportDto model)
        {
            return Ok(await _controller.CreateTransportsAsync(model));
        }

        [HttpPut("api/Transport/{id}")]
        public async Task<IActionResult> EditTransportAsync(uint id, [FromBody]TransportDto model)
        {
            return Ok(await _controller.EditTransportsAsync(id, model));
        }

        [HttpDelete("api/Transport/{id}")]
        public async Task<IActionResult> DeleteTransportByIdAsync(uint id)
        {
            return Ok(await _controller.DeleteTransportsByIdAsync(id));
        }
    }
}