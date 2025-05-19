using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/delivery-types")]
    public class DeliveryTypesController : HatController
    {
        public DeliveryTypesController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetDeliveryTypes()
        {
            var list = await _mediator.Send(new DeliveryTypesQuery());
            return Ok(list);
        }
    }
}
