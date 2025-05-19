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
        public TracksController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTracks()
        {
            var list = await _mediator.Send(new TracksQuery());
            return Ok(list);
        }
    }
}
