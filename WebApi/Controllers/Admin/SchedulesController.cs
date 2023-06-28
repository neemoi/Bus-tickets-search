using Application.Services.DtoModels.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    public class SchedulesController : ControllerBase
    {
        private readonly ScheduleRepository _controller;

        public SchedulesController(ScheduleRepository repository)
        {
            _controller = repository;
        }

        [HttpGet("api/Schedule")]
        public async Task<IActionResult> GetAllSheduleAsync()
        {
            return Ok(await _controller.GetAllSсheduleAsync());
        }

        [HttpGet("api/Schedule/{id}")]
        public async Task<IActionResult> GetByIdSheduleAsync(uint id)
        {
            return Ok(await _controller.GetByIdSсheduleAsync(id));
        }

        [HttpPost("api/Schedule")]
        public async Task<IActionResult> CreateSheduleAsync([FromQuery]ScheduleDto model)
        {
            return Ok(await _controller.CreateSсheduleAsync(model));
        }

        [HttpPut("api/Schedule/{id}")]
        public async Task<IActionResult> EditSheduleAsync(uint id, ScheduleDto model)
        {
            return Ok(await _controller.EditSсheduleAsync(id, model));
        }

        [HttpDelete("api/Schedule/{id}")]
        public async Task<IActionResult> DeleteSheduleByIdAsync(uint id)
        {
            return Ok(await _controller.DeleteSсheduleByIdAsync(id));
        }
    }
}