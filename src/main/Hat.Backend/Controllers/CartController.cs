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
        public CartController(IMediator mediator, ILogger<CartController> logger,ICurrentUser currentUser) : base(mediator, logger,currentUser)
        {
        }
        [HttpGet("")]
        public async Task<IActionResult> GetCart()
        {
            _logger.LogInformation("GetCarts");
            var cart = await _mediator.Send(new CartByUserQuery(_currentUser.Oid()));
            return Ok(cart);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserCart()
        {
            _logger.LogInformation("GetCart By User");
            var cart = await _mediator.Send(new CartByUserQuery(_currentUser.Oid()));
            return Ok(cart);
        }
    }
}
