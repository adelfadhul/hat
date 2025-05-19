using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : HatController
    {
        public CategoriesController(IMediator mediator, ILogger<CategoriesController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCategories()
        {
            _logger.LogInformation("GetCategories");
            var list = await _mediator.Send(new CategoriesQuery());
            return Ok(list);
        }

      
    }
}
