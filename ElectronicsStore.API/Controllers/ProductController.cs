using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStore.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{category}")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetProductsByCategory([FromRoute]string category, [FromQuery]int? page)
        {
            var products = await _productService.GetProductsByCategoryAsync(category, page);

            return Ok(products);
        }
        
        [HttpGet("getby/{name}")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetProductByName([FromRoute] string name)
        {
            var products = await _productService.GetProductByNameAsync(name);

            return Ok(products.DataFromServer);
        }
        [HttpGet("search/{search}")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetProductBySearch([FromRoute] string search, [FromQuery] int? page)
        {
            var products = await _productService.GetProductsBySearchAsync(search, page);

            return Ok(products);
        }

    }
}
