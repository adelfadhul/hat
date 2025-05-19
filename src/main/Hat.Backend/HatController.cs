using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend
{
    public class HatController : Controller
    {
        protected readonly IMediator _mediator;
        protected readonly ILogger<HatController> _logger;
        public HatController(IMediator mediator, ILogger<HatController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
       
    }
}
