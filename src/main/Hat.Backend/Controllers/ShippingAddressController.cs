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
    }
}
