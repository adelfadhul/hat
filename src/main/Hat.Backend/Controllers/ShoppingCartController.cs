using Hat.Domain.Queries;
using Hat.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hat.Backend.Controllers
{
    [ApiController]
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
        public async Task<IActionResult> AddToCart([FromBody] AddShoppingCartItemCommand command)
        {
            _logger.LogInformation("AddToCart: {@Command}", command);
          await _mediator.Send(command);
            return Ok();
        }

        // POST: api/shopping-cart/remove
        [HttpPost("remove")]
        public async Task<IActionResult> RemoveFromCart([FromBody] RemoveShoppingCartItemCommand command)
        {
            _logger.LogInformation("RemoveFromCart: {@Command}", command);
           await _mediator.Send(command);
            return Ok();
        }
    }
}
