using Hat.Domain.Commands;
using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/inventories")]
    public class InventoryController : HatController
    {
        public InventoryController(IMediator mediator, ILogger<HatController> logger,ICurrentUser currentUser) : base(mediator, logger, currentUser)
        {
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetInventories([FromRoute] Guid productId)
        {
            var inventories = await _mediator.Send(new InventoriesByProductQuery(productId));
            if (inventories == null || inventories.Count == 0)
            {
                return NotFound();
            }
            _logger.LogInformation("GetInventories: ProductId={ProductId}", productId);
            return Ok(inventories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryCommand command)
        {
            _logger.LogInformation("CreateInventory: {command}", command);
            var result = await _mediator.Send(command);
            // assuming result is the new inventory ID
            return CreatedAtAction(nameof(GetInventories), new { productId = command.ProductId }, new { id = result });
        }

    }
}
