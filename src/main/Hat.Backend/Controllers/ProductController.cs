using Hat.Domain.Commands;
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


        [HttpPost()]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            _logger.LogInformation("CreateProduct: {ProductName}", command.Name);
            var result = await _mediator.Send(command);

            // assuming result is the new product ID
            return CreatedAtAction(nameof(GetProductById), new { id = result }, new { id = result });
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id, [FromQuery] bool detailed)
        {
            _logger.LogInformation("GetProductById: {ProductId}", id);
            var isDetailed = false;
            if (detailed)
            {
                isDetailed = true;
            }
            var product = await _mediator.Send(new ProductByIdQuery(id, isDetailed));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(Guid categoryId)
        {
            _logger.LogInformation("GetProductsByCategory: {CategoryId}", categoryId);
            var products = await _mediator.Send(new ProductsByCategoryQuery(categoryId));
            return Ok(products);
        }
        [HttpGet("wish/{userId}")]
        public async Task<IActionResult> GetWishProducts(Guid userId)
        {
            _logger.LogInformation("GetWishProducts: {UserId}", userId);
            var products = await _mediator.Send(new UserWishProductsQuery(userId));
            return Ok(products);
        }
    }
}
