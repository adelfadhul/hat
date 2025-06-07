using Hat.Domain.Commands;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/shopping-cart")]
    public class ShoppingCartController : HatController
    {
        public ShoppingCartController(IMediator mediator, ILogger<ShoppingCartController> logger)
            : base(mediator, logger)
        {
        }

        // GET: api/shopping-cart/{userId}
        [HttpGet("")]
        public async Task<IActionResult> GetCart()
        {
            _logger.LogInformation("GetCart");
            var cartItems = await _mediator.Send(new ShoppingCartQuery());
            return Ok(cartItems);
        }

        // POST: api/shopping-cart/add
        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CreateCartItemCommand command)
        {
            _logger.LogInformation("AddToCart: {@Command}", command);
            await _mediator.Send(command);
            return Ok();
        }

        // POST: api/shopping-cart/remove
        [HttpPost("remove")]
        public async Task<IActionResult> RemoveFromCart([FromBody] DeleteCartItemCommand command)
        {
            _logger.LogInformation("RemoveFromCart: {@Command}", command);
           await _mediator.Send(command);
            return Ok();
        }
    }
}
