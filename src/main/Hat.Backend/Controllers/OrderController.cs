using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/user/orders")]
    public class OrderController : HatController
    {
        public OrderController(IMediator mediator, ILogger<OrderController> logger, IUserContext userContext) : base(mediator, logger, userContext)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetOrders()
        {
            _logger.LogInformation("GetOrders");
            var userId = _userContext.GetUserId();
            var list = await _mediator.Send(new OrdersByUserQuery(userId));
            return Ok(list);
        }
    }
}