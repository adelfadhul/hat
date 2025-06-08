using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/user/cart")]
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
    }
}
