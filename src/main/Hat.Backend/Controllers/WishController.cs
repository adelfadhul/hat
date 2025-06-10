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
        public WishController(IMediator mediator, ILogger<WishController> logger, IUserContext userContext) : base(mediator, logger, userContext)
        {
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetWishes()
        {
            _logger.LogInformation("GetWishes By User");
            var userId = _userContext.GetUserId();
            var list = await _mediator.Send(new UserWishProductsQuery(userId));
            CheckUser(list.FirstOrDefault(), userId);
            return Ok(list);
        }
        [HttpGet("user/products/{ProductId}")]
        public async Task<IActionResult> GetWishByUserAndProduct([FromRoute] Guid UserId, [FromRoute] Guid ProductId)
        {
            var userId = _userContext.GetUserId();
            var wish = await _mediator.Send(new WishByUserAndProductQuery(UserId, ProductId));
            if (wish == null)
            {
                return NotFound();
            }

            _logger.LogInformation("GetWishByUserAndProduct: UserId={UserId}, ProductId={ProductId}", UserId, ProductId);
            CheckUser(wish, userId);
            return Ok(wish);
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteWish([FromQuery] Guid WishId)
        {
            _logger.LogInformation("DeleteWish By User");

            // Retrieve the wish to check ownership
            var wish = await _mediator.Send(new WishByIdQuery(WishId));
            if (wish == null)
            {
                return NotFound();
            }

            // Check if the wish belongs to the current user
            var userId = _userContext.GetUserId();
            CheckUser(wish, userId);

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