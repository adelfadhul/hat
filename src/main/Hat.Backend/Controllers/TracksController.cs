using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/tracks")]
    public class TracksController : HatController
    {
        public TracksController(IMediator mediator, ILogger<TracksController> logger) : base(mediator, logger)
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
