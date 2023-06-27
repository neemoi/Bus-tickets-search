using Application.Services.DtoModels.DtoModels;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleRepository _controller;

        public ScheduleController(ScheduleRepository repository)
        {
            _controller = repository;
        }

        [HttpGet("api/Schedules")]
        public async Task<IActionResult> GetAllSheduleAsync()
        {
            return Ok(await _controller.GetAllSheduleAsync());
        }

        [HttpGet("api/Schedule/{id}")]
        public async Task<IActionResult> GetByIdSheduleAsync(uint id)
        {
            return Ok(await _controller.GetByIdSheduleAsync(id));
        }

        [HttpPost("api/Schedules")]
        public async Task<IActionResult> CreateSheduleAsync([FromQuery]ScheduleDto model)
        {
            return Ok(await _controller.CreateSheduleAsync(model));
        }

        [HttpPut("api/Schedule/{id}")]
        public async Task<IActionResult> EditSheduleAsync(uint id, ScheduleDto model)
        {
            return Ok(await _controller.EditSheduleAsync(id, model));
        }

        [HttpDelete("api/Schedule/{id}")]
        public async Task<IActionResult> DeleteSheduleByIdAsync(uint id)
        {
            return Ok(await _controller.DeleteSheduleByIdAsync(id));
        }
    }
}
