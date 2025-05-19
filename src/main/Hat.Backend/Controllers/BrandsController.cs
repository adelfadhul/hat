using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : HatController
    {
        public BrandsController(IMediator mediator, ILogger<BrandsController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetBrands()
        {
            _logger.LogInformation("GetBrands");
            var list = await _mediator.Send(new BrandsQuery());
            return Ok(list);
        }
    }
}
