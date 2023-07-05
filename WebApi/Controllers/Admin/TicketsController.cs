using Application.DtoModels.Models.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("api/Ticket")]
        public async Task<IActionResult> GetAllTicketsAsync()
        {
            return Ok(await _ticketService.GetAllTicketsAsync());
        }

        [HttpGet("api/Ticket/{id}")]
        public async Task<IActionResult> GetByIdTicketAsync(uint idTicket)
        {
            return Ok(await _ticketService.GetByIdTicketAsync(idTicket));
        }

        [HttpPost("api/Ticket")]
        public async Task<IActionResult> CreateTicketAsync(TicketDto model)
        {
            return Ok(await _ticketService.CreateTicketAsync(model));
        }

        [HttpPut("api/Ticket/{id}")]
        public async Task<IActionResult> EditTicketAsync(uint idTicket, TicketDto model)
        {
            return Ok(await _ticketService.EditTicketAsync(idTicket, model));
        }

        [HttpDelete("api/Ticket/{id}")]
        public async Task<IActionResult> DeleteTicketByIdAsync(uint idTicket)
        {
            return Ok(await _ticketService.DeleteTicketByIdAsync(idTicket));
        }
    }
}