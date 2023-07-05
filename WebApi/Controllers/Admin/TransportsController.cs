using Application.DtoModels.Models.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class TransportsController : ControllerBase
    {
        private readonly ITransportService _transportService;

        public TransportsController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        [HttpGet("api/Transport")]
        public async Task<IActionResult> GetAllTransportAsync()
        {
            return Ok(await _transportService.GetAllTransportsAsync());
        }

        [HttpGet("api/Transport/{id}")]
        public async Task<IActionResult> GetByIdTransportAsync(uint id)
        {
            return Ok(await _transportService.GetByIdTransportsAsync(id));
        }

        [HttpPost("api/Transport")]
        public async Task<IActionResult> CreateTransportAsync([FromBody] TransportDto model)
        {
            return Ok(await _transportService.CreateTransportsAsync(model));
        }

        [HttpPut("api/Transport/{id}")]
        public async Task<IActionResult> EditTransportAsync(uint id, [FromBody] TransportDto model)
        {
            return Ok(await _transportService.EditTransportsAsync(id, model));
        }

        [HttpDelete("api/Transport/{id}")]
        public async Task<IActionResult> DeleteTransportByIdAsync(uint id)
        {
            return Ok(await _transportService.DeleteTransportsByIdAsync(id));
        }
    }
}