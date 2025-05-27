using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/shipping-address")]
    public class ShippingAddressController : HatController
    {
        public ShippingAddressController(IMediator mediator, ILogger<ShippingAddressController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetShippingAddresses()
        {
            _logger.LogInformation("GetShippingAddresses");
            var shippingAddresses = await _mediator.Send(new ShippingAddressesQuery());
            return Ok(shippingAddresses);
        }
        [HttpGet("primary/{UserId}")]
        public async Task<IActionResult> GetPrimaryShippingAddress([FromRoute]Guid UserId)
        {
            _logger.LogInformation("GetPrimaryShippingAddress");
            var primaryAddress = await _mediator.Send(new PrimaryShippingAddressQuery(UserId));
            if (primaryAddress == null)
            {
                return NotFound();
            }
            return Ok(primaryAddress);
        }

        
    }
}
