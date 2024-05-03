using FitFriends.API.Contracts.Orders;
using FitFriends.Application.Interfaces;
using FitFriends.Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitFriends.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok();
        }

        
        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] IOrderService orderService,
            [FromBody] CreateOrderRequest request)
        {
            Order order = new()
            {
                Name = request.Name,
            };

            await orderService.CreateAsync(order);

            return Ok();
        }
    }
}
