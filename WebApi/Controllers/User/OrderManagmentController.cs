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

        [HttpGet("api/OrderManagement")]
        public async Task<IActionResult> GetInfoByIdTicketAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(await _orderManagementRepository.GetInfoByIdTicketAsync(userId));
        }

        [HttpDelete("api/OrderManagement")]
        public async Task<IActionResult> TicketCancellationAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(await _orderManagementRepository.TicketCancelAtionAsync(userId));
        }
    }
}