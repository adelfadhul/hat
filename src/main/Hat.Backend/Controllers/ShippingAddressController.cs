using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/shipping-addresses")]
    public class ShippingAddressController : HatController
    {
        public ShippingAddressController(IMediator mediator, ILogger<ShippingAddressController> logger,ILoginService loginService)
            : base(mediator, logger, loginService)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetShippingAddresses()
        {
            _logger.LogInformation("GetShippingAddresses");
            var shippingAddresses = await _mediator.Send(new ShippingAddressesQuery());
            ForbidIfUserIdMismatch(shippingAddresses.FirstOrDefault());
            return Ok(shippingAddresses);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserShippingAddresses()
        {
            _logger.LogInformation("GetShippingAddressesByUser");
            var shippingAddresses = await _mediator.Send(new ShippingAddressesByUserQuery(_currentUser.Oid()));
            ForbidIfUserIdMismatch(shippingAddresses.FirstOrDefault());
            return Ok(shippingAddresses);
        }
        [HttpGet("user/primary")]
        public async Task<IActionResult> GetUserPrimaryShippingAddress()
        {
            _logger.LogInformation("GetPrimaryShippingAddress");
            var primaryAddress = await _mediator.Send(new PrimaryShippingAddressQuery(_currentUser.Oid()));
            if (primaryAddress == null)
            {
                return NotFound();
            }
            ForbidIfUserIdMismatch(primaryAddress);
            return Ok(primaryAddress);
        }

        
    }
}
