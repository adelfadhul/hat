using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : HatController
    {
        public BrandController(IMediator mediator, ILogger<BrandController> logger,ILoginService loginService) : base(mediator, logger, loginService)
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
