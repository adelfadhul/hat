using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/delivery-steps")]
    public class DeliveryStepController : HatController
    {
        public DeliveryStepController(IMediator mediator, ILogger<DeliveryStepController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetDeliverySteps()
        {
            _logger.LogInformation("GetDeliverySteps");
            var list = await _mediator.Send(new DeliveryStepsQuery());
            return Ok(list);
        }
    }
}
