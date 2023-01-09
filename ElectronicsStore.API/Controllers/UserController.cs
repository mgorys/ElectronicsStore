using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Models.Dto;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace ElectronicsStore.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/order")]
    public class UserController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public UserController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersAsync()
        {
            var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;
            var orders = await _orderService.GetUsersOrdersAsync(userEmail);

            return Ok(orders);
        }
        [HttpGet("{orderNumber}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersAsync([FromRoute] int orderNumber)
        {
            var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;
            var orders = await _orderService.GetUsersOrderByIdAsync(userEmail,orderNumber);

            return Ok(orders);
        }
    }
}
