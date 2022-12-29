using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ElectronicsStore.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public AdminController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("order")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersAsync()
        {
            var orders = await _orderService.GetOrdersAsync();

            return Ok(orders);
        }
        [HttpGet("order/{number}")]
        public async Task<ActionResult<ServerResponseOrderAndItems<IEnumerable<PurchaseItemDto>>>> GetOrderByNumberAsync(int number)
        {
            var order = await _orderService.GetOrderByNumberAsync(number);

            return Ok(order);
        }
    }
}
