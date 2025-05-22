using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/delivery-types")]
    public class DeliveryTypeController : HatController
    {
        public DeliveryTypeController(IMediator mediator, ILogger<DeliveryTypeController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetDeliveryTypes()
        {
            _logger.LogInformation("GetDeliveryTypes");
            var list = await _mediator.Send(new DeliveryTypesQuery());
            return Ok(list);
        }
    }
}
