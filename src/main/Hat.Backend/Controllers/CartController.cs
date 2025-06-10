using Hat.Domain.Commands;
using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/carts")]
    public class CartController : HatController
    {
        public CartController(IMediator mediator, ILogger<CartController> logger, IUserContext userContext) : base(mediator, logger, userContext)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCart()
        {
            _logger.LogInformation("GetCarts");
            var userId = _userContext.GetUserId();
            var cart = await _mediator.Send(new CartByUserQuery(userId));
            CheckUser(cart, userId);
            return Ok(cart);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserCart()
        {
            _logger.LogInformation("GetCart By User");
            var userId = _userContext.GetUserId();
            var cart = await _mediator.Send(new CartByUserQuery(userId));
            if (cart == null)
            {
                return NotFound("Cart not found for the current user.");
            }
            CheckUser(cart, userId);
            return Ok(cart);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCart()
        {
            _logger.LogInformation("CreateCart");
            var cart = await _mediator.Send(new CreateCartCommand());
          
            return CreatedAtAction(nameof(GetCart), new { id = cart.Id }, cart);
        }
    }
}
