using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardsController : HatController
    {
        public CardsController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCards()
        {
            var list = await _mediator.Send(new CardsQuery());
            return Ok(list);
        }
    }
}
