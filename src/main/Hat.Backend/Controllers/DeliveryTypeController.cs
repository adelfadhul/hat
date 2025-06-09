using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/delivery-types")]
    public class DeliveryTypeController : HatController
    {
        public DeliveryTypeController(IMediator mediator, ILogger<DeliveryTypeController> logger, ILoginService loginService) : base(mediator, logger, loginService)
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
