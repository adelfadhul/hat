using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/trackorders")]
    public class TrackOrdersController : HatController
    {
        public TrackOrdersController(IMediator mediator, ILogger<TrackOrdersController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTracks()
        {
            _logger.LogInformation("GetTracks");
            var list = await _mediator.Send(new TracksQuery());
            return Ok(list);
        }
    }
}
