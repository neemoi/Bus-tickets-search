using Application.DtoModels.Models.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("api/Driver")]
        public async Task<IActionResult> GetAllDriverAsync()
        {
            return Ok(await _driverService.GetAllDriversAsync());
        }

        [HttpGet("api/Driver/{id}")]
        public async Task<IActionResult> GetByIdDriverAsync(uint id)
        {
            return Ok(await _driverService.GetByIdDriversAsync(id));
        }

        [HttpPost("api/Driver")]
        public async Task<IActionResult> CreatNewDriverAsync([FromQuery] DriverDto model)
        {
            return Ok(await _driverService.CreateDriverAsync(model));
        }

        [HttpPut("api/Driver/{id}")]
        public async Task<IActionResult> EditDriverAsync(uint id, DriverDto model)
        {
            return Ok(await _driverService.EditDriversAsync(id, model));
        }

        [HttpDelete("api/Driver/{id}")]
        public async Task<IActionResult> DeleteDriverByIdAsync(uint id)
        {
            return Ok(await _driverService.DeleteDriversByIdAsync(id));
        }
    }
}