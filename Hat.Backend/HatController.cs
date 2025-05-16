using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend
{
    public class HatController : Controller
    {
        protected readonly IMediator _mediator;
        protected readonly ILogger _logger;
        public HatController(IMediator mediator, ILogger logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet("")]
        public IActionResult GetList()
        {
            return View();
        }
    }
}
