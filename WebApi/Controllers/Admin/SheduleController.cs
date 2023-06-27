using Application.Services.DtoModels.DtoModels.Shedule;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    public class SheduleController : ControllerBase
    {
        private readonly SheduleRepository _controller;

        public SheduleController(SheduleRepository repository)
        {
            _controller = repository;
        }

        [HttpGet("/api/GetAllShedule")]
        public async Task<IActionResult> GetAllSheduleAsync()
        {
            return Ok(await _controller.GetAllSheduleAsync());
        }

        [HttpGet("/api/GetByIdShedule")]
        public async Task<IActionResult> GetByIdSheduleAsync(uint idShedule)
        {
            return Ok(await _controller.GetByIdSheduleAsync(idShedule));
        }

        [HttpPost("/api/CreateShedule")]
        public async Task<IActionResult> CreateSheduleAsync(CreateSheduleDto model)
        {
            return Ok(await _controller.CreateSheduleAsync(model));
        }

        [HttpPost("/api/EditShedule")]
        public async Task<IActionResult> EditSheduleAsync(uint idShedule, EditSheduleDto model)
        {
            return Ok(await _controller.EditSheduleAsync(idShedule, model));
        }

        [HttpDelete("/api/DeleteSheduleById")]
        public async Task<IActionResult> DeleteSheduleByIdAsync(uint idShedule)
        {
            return Ok(await _controller.DeleteSheduleByIdAsync(idShedule));
        }
    }
}
