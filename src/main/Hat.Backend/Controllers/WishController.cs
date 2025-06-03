using Hat.Application.Queries;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/wishes")]
    public class WishController : HatController
    {
        public WishController(IMediator mediator, ILogger<WishController> logger) : base(mediator, logger)
        {
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetWishes([FromQuery] Guid UserId)
        {
            _logger.LogInformation("GetWishes By User");
            var list = await _mediator.Send(new WishesByUserQuery(UserId));
            return Ok(list);
        }
    }
}