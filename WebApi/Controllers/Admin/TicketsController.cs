using Application.Services.DtoModels.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    public class TicketsController : Controller
    {
        private readonly TicketRepository _ticketRepository;

        public TicketsController(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        
        [HttpGet("api/GetAllTickets")]
        public async Task<IActionResult> GetAllTicketsAsync()
        {
            return Ok(await _ticketRepository.GetAllTicketsAsync());
        }

        [HttpGet("api/GetByIdTicket")]
        public async Task<IActionResult> GetByIdTicketAsync(uint idTicket)
        {
            return Ok(await _ticketRepository.GetByIdTicketAsync(idTicket));
        }

        [HttpPost("api/CreateTicket")]
        public async Task<IActionResult> CreateTicketAsync(TicketDto model)
        {
            return Ok(await _ticketRepository.CreateTicketAsync(model));
        }

        [HttpPut("api/EditTicket")]
        public async Task<IActionResult> EditTicketAsync(uint idTicket, TicketDto model)
        {
            return Ok(await _ticketRepository.EditTicketAsync(idTicket, model));
        }

        [HttpDelete("api/DeleteTicketById")]
        public async Task<IActionResult> DeleteTicketByIdAsync(uint idTicket)
        {
            return Ok(await _ticketRepository.DeleteTicketByIdAsync(idTicket));
        }
    }
}
