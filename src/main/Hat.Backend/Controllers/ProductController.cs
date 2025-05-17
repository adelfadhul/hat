using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("/api/products")]    
    public class ProductController : HatController
    {
        public ProductController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetList()
        {
           var list= await _mediator.Send( new ProductsQuery() );  
            return Ok(list);    
        }
    }
}
