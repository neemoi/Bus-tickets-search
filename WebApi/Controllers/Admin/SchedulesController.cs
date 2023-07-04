using Application.Services.DtoModels.Models.Admin;
using Application.Services.Interfaces.IRepository.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class SchedulesController : ControllerBase
    {
        private readonly ISсheduleRepository _sсheduleRepository;

        public SchedulesController(ScheduleRepository repository)
        {
            _sсheduleRepository = repository;
        }

        [HttpGet("api/Schedule")]
        public async Task<IActionResult> GetAllSheduleAsync()
        {
            return Ok(await _sсheduleRepository.GetAllSсhedulesAsync());
        }

        [HttpGet("api/Schedule/{id}")]
        public async Task<IActionResult> GetByIdSheduleAsync(uint id)
        {
            return Ok(await _sсheduleRepository.GetByIdSсhedulesAsync(id));
        }

        [HttpPost("api/Schedule")]
        public async Task<IActionResult> CreateSheduleAsync([FromQuery] ScheduleDto model)
        {
            return Ok(await _sсheduleRepository.CreateSсhedulesAsync(model));
        }

        [HttpPut("api/Schedule/{id}")]
        public async Task<IActionResult> EditSheduleAsync(uint id, ScheduleDto model)
        {
            return Ok(await _sсheduleRepository.EditSсhedulesAsync(id, model));
        }

        [HttpDelete("api/Schedule/{id}")]
        public async Task<IActionResult> DeleteSheduleByIdAsync(uint id)
        {
            return Ok(await _sсheduleRepository.DeleteSсhedulesByIdAsync(id));
        }
    }
}