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
        public CartController(IMediator mediator, ILogger<CartController> logger, ILoginService loginService) : base(mediator, logger, loginService)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCart()
        {
            _logger.LogInformation("GetCarts");
            var cart = await _mediator.Send(new CartByUserQuery(_currentUser.Oid()));
            var forbidResult = ForbidIfUserIdMismatch(cart);
            if (forbidResult != null)
            {
                return forbidResult;
            }
            return Ok(cart);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserCart()
        {
            _logger.LogInformation("GetCart By User");
            var cart = await _mediator.Send(new CartByUserQuery(_currentUser.Oid()));
            if (cart == null)
            {
                return NotFound("Cart not found for the current user.");
            }
            var forbidResult = ForbidIfUserIdMismatch(cart);
            if (forbidResult != null)
            {
                return forbidResult;
            }
            return Ok(cart);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCart()
        {
            _logger.LogInformation("CreateCart");
            var cart = await _mediator.Send(new CreateCartCommand());
            var forbidResult = ForbidIfUserIdMismatch(cart);
            if (forbidResult != null)
            {
                return forbidResult;
            }
            return CreatedAtAction(nameof(GetCart), new { id = cart.Id }, cart);
        }
    }
}
