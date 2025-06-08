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
        public OrderController(IMediator mediator, ILogger<OrderController> logger,ICurrentUser currentUser) : base(mediator, logger, currentUser)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetOrders()
        {
            _logger.LogInformation("GetOrders");
            var list = await _mediator.Send(new OrdersByUserQuery(_currentUser.Oid()));
            return Ok(list);
        }
    }
}