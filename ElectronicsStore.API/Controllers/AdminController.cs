using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.NetworkInformation;

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
        
        [HttpGet("order/{number}")]
        public async Task<ActionResult<ServerResponseOrderDateString<IEnumerable<PurchaseItemDto>>>> GetOrderByNumberAsync(int number)
        {
            var order = await _orderService.GetOrderByNumberAsync(number);

            return Ok(order);
        }
        [HttpGet("order")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersAsync([FromQuery] Query query)
        {
            var orders = await _orderService.GetOrdersAsync(query);

            return Ok(orders);
        }
        [HttpPost("order/status")]
        public async Task<ActionResult<ServerResponseOrderDateString<IEnumerable<PurchaseItemDto>>>> 
            ChangeOrderStatusByNumberAsync([FromBody] ChangeStatusByNumberDto data)
        {
            var order = await _orderService.ChangeOrderStatusByNumberAsync(data);

            return Ok(order);
        }
    }
}
