using Hat.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend
{
    public class HatController : Controller
    {
        protected readonly IMediator _mediator;
        protected readonly ILogger<HatController> _logger;
        protected readonly ICurrentUser _currentUser;
        public HatController(IMediator mediator, ILogger<HatController> logger, ICurrentUser currentUser)
        {
            _logger = logger;
            _mediator = mediator;
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser), "Current user cannot be null. Ensure that the ICurrentUser service is registered in the DI container.");
        }
       
    }
}
