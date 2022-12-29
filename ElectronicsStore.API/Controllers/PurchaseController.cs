using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStore.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/purchase")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostPurchase([FromBody] PurchaseDataDto<IEnumerable<PurchaseItemDto>> purchase)
        {
            var products = await _purchaseService.PostPurchaseAsync(purchase);
            
            return Ok(products);
        }
    }
}
