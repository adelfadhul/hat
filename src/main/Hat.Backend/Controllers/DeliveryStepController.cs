using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/delivery-steps")]
    public class DeliveryStepController : HatController
    {
        public DeliveryStepController(IMediator mediator, ILogger<DeliveryStepController> logger, IUserContext userContext) : base(mediator, logger, userContext)
        {
        }

        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetDeliverySteps([FromRoute] Guid OrderId)
        {
            _logger.LogInformation($"GetDeliverySteps of {OrderId}");
            var list = await _mediator.Send(new DeliveryStepsByOrderQuery(OrderId));
            return Ok(list);
        }
    }
}
