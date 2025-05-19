using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoriesController : HatController
    {
        public CategoriesController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetList()
        {
            var list = await _mediator.Send(new CategoriesQuery());
            return Ok(list);
        }

      
    }
}
