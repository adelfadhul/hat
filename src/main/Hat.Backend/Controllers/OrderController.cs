using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : HatController
    {
        public OrderController(IMediator mediator, ILogger<OrderController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetOrders()
        {
            _logger.LogInformation("GetOrders");
            var list = await _mediator.Send(new OrdersQuery());
            return Ok(list);
        }
    }
}