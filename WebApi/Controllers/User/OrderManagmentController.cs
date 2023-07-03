using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.User;
using System.Security.Claims;

namespace WebApi.Controllers.User
{
    public class OrderManagmentController : Controller
    {
       private readonly OrderManagementRepository _orderManagementRepository;

        public OrderManagmentController(OrderManagementRepository orderManagementRepository)
        {
            _orderManagementRepository = orderManagementRepository; 
        }

        [HttpGet("api/InfoTicket")]
        public async Task<IActionResult> GetInfoTicketAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(await _orderManagementRepository.GetInfoTicketAsync(userId));
        }

        [HttpDelete("api/Ticket")]
        public async Task<IActionResult> TicketCancellationAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(await _orderManagementRepository.TicketCancellationAsync(userId));
        }
    }
}
