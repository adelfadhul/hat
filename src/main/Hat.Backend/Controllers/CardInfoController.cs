using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/card-infos")]
    public class CardInfoController : HatController
    {
        public CardInfoController(IMediator mediator, ILogger<CardInfoController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCardInfos()
        {
            _logger.LogInformation("GetCardInfos");
            var list = await _mediator.Send(new CardInfosQuery());
            return Ok(list);
        }
    }
}
