using Application.DtoModels.Models.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("api/Schedule")]
        public async Task<IActionResult> GetAllSheduleAsync()
        {
            return Ok(await _scheduleService.GetAllSсhedulesAsync());
        }

        [HttpGet("api/Schedule/{id}")]
        public async Task<IActionResult> GetByIdSheduleAsync(uint id)
        {
            return Ok(await _scheduleService.GetByIdSсhedulesAsync(id));
        }

        [HttpPost("api/Schedule")]
        public async Task<IActionResult> CreateSheduleAsync([FromQuery] ScheduleDto model)
        {
            return Ok(await _scheduleService.CreateSсhedulesAsync(model));
        }

        [HttpPut("api/Schedule/{id}")]
        public async Task<IActionResult> EditSheduleAsync(uint id, ScheduleDto model)
        {
            return Ok(await _scheduleService.EditSсhedulesAsync(id, model));
        }

        [HttpDelete("api/Schedule/{id}")]
        public async Task<IActionResult> DeleteSheduleByIdAsync(uint id)
        {
            return Ok(await _scheduleService.DeleteSсhedulesByIdAsync(id));
        }
    }
}