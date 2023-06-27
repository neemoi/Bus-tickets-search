using Application.Services.DtoModels.DtoModels.Transport;
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

        [HttpGet("/api/GetAllTransport")]
        public async Task<IActionResult> GetAllTransportAsync()
        {
            return Ok(await _controller.GetAllTransportAsync());
        }

        [HttpGet("/api/GetByIdTransport")]
        public async Task<IActionResult> GetByIdTransportAsync(uint idTransport)
        {
            return Ok(await _controller.GetByIdTransportAsync(idTransport));
        }

        [HttpPost("/api/CreateTransport")]
        public async Task<IActionResult> CreatTransportAsync(CreateTransportDto model)
        {
            return Ok(await _controller.CreateTransportAsync(model));
        }

        [HttpPost("/api/EditTransport")]
        public async Task<IActionResult> EditTransportAsync(uint idTransport, EditTransportDto model)
        {
            return Ok(await _controller.EditTransportAsync(idTransport, model));
        }

        [HttpDelete("/api/DeleteTransportById")]
        public async Task<IActionResult> DeleteTransportByIdAsync(uint idTransport)
        {
            return Ok(await _controller.DeleteTransportByIdAsync(idTransport));
        }
    }
}
