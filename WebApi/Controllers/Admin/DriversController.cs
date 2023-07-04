using Application.Services.DtoModels.Models.Admin;
using Application.Services.Interfaces.IRepository.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class DriversController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;

        public DriversController(DriverRepository repository)
        {
            _driverRepository = repository;
        }

        [HttpGet("api/Driver")]
        public async Task<IActionResult> GetAllDriverAsync()
        {
            return Ok(await _driverRepository.GetAllDriversAsync());
        }

        [HttpGet("api/Driver/{id}")]
        public async Task<IActionResult> GetByIdDriverAsync(uint id)
        {
            return Ok(await _driverRepository.GetByIdDriversAsync(id));
        }

        [HttpPost("api/Driver")]
        public async Task<IActionResult> CreatNewDriverAsync([FromQuery]DriverDto model)
        {
            return Ok(await _driverRepository.CreateDriverAsync(model));
        }

        [HttpPut("api/Driver/{id}")]
        public async Task<IActionResult> EditDriverAsync(uint id, DriverDto model)
        {
            return Ok(await _driverRepository.EditDriversAsync(id, model));
        }

        [HttpDelete("api/Driver/{id}")]
        public async Task<IActionResult> DeleteDriverByIdAsync(uint id)
        {
            return Ok(await _driverRepository.DeleteDriversByIdAsync(id));
        }
    }
}