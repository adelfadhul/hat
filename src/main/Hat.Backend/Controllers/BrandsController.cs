using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : HatController
    {
        public BrandsController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetBrands()
        {
            var list = await _mediator.Send(new BrandsQuery());
            return Ok(list);
        }
    }
}
