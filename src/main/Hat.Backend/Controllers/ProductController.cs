using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/products")]    
public class ProductController : HatController
    {
        public ProductController(IMediator mediator, ILogger<ProductController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation("GetProducts");
            var list = await _mediator.Send(new ProductsQuery());
            return Ok(list);
        }

        [HttpGet("best-selling")]
        public async Task<IActionResult> GetBestSellingProducts()
        {
            var products = await _mediator.Send(new BestSellingProductsQuery());
            return Ok(products);
        }

        [HttpGet("featured-brand")]
        public async Task<IActionResult> GetFeaturedProducts()
        {
            var products = await _mediator.Send(new FeaturedProductsQuery());
            return Ok(products);
        }
    }
}
