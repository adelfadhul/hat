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
        public ShippingAddressController(IMediator mediator, ILogger<ShippingAddressController> logger,IUserContext userContext)
            : base(mediator, logger, userContext)
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
            var userId = _userContext.GetUserId();  
            var shippingAddresses = await _mediator.Send(new ShippingAddressesByUserQuery(userId));
            ForbidIfUserIdMismatch(shippingAddresses.FirstOrDefault());
            return Ok(shippingAddresses);
        }
        [HttpGet("user/primary")]
        public async Task<IActionResult> GetUserPrimaryShippingAddress()
        {
            _logger.LogInformation("GetPrimaryShippingAddress");
            var userId = _userContext.GetUserId();
            var primaryAddress = await _mediator.Send(new PrimaryShippingAddressQuery(userId));
            if (primaryAddress == null)
            {
                return NotFound();
            }
            ForbidIfUserIdMismatch(primaryAddress);
            return Ok(primaryAddress);
        }

        
    }
}
