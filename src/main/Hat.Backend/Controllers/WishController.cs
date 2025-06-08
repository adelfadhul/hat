using Hat.Application.Queries;
using Hat.Domain.Commands;
using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/wishes")]
    public class WishController : HatController
    {
        public WishController(IMediator mediator, ILogger<WishController> logger,ICurrentUser currentUser) : base(mediator, logger, currentUser)
        {
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetWishes()
        {
            _logger.LogInformation("GetWishes By User");
            var list = await _mediator.Send(new UserWishProductsQuery(_currentUser.Oid()));
            return Ok(list);
        }
        [HttpGet("{UserId}/products/{ProductId}")]
        public async Task<IActionResult> GetWishByUserAndProduct([FromRoute] Guid UserId, [FromRoute] Guid ProductId)
        {
            var wish = await _mediator.Send(new WishByUserAndProductQuery(UserId, ProductId));
            if (wish == null)
            {
                return NotFound();
            }

            _logger.LogInformation("GetWishByUserAndProduct: UserId={UserId}, ProductId={ProductId}", UserId, ProductId);
            return Ok(wish);
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteWish([FromQuery] Guid WishId)
        {
            _logger.LogInformation("DeleteWish By User");
            var result = await _mediator.Send(new DeleteWishCommand(WishId));
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWish([FromBody] CreateWishCommand command)
        {
            _logger.LogInformation("CreateWish: {command}", command);
            var result = await _mediator.Send(command);
            // assuming result is the new wish ID
            return CreatedAtAction(nameof(GetWishes), new { UserId = command.UserId }, new { id = result });
        }
    }
}