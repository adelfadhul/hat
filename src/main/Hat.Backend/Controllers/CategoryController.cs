using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/categories")]
    public class CategoryController : HatController
    {
        public CategoryController(IMediator mediator, ILogger<CategoryController> logger,IUserContext userContext) : base(mediator, logger, userContext)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCategories()
        {
            _logger.LogInformation("GetCategories");
          

            var list = await _mediator.Send(new CategoriesQuery());
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            _logger.LogInformation("GetCategoryById: {CategoryId}", id);
            var category = await _mediator.Send(new CategoryByIdQuery(id));
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

       
    }
}
