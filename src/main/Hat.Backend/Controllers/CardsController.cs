using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardsController : HatController
    {
        public CardsController(IMediator mediator, ILogger<CardsController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCards()
        {
            _logger.LogInformation("GetCards");
            var list = await _mediator.Send(new CardsQuery());
            return Ok(list);
        }
    }
}
