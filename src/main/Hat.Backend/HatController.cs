using Hat.Domain.Identity;
using Hat.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend
{
    public class HatController : Controller
    {
        protected readonly IMediator _mediator;
        protected readonly ILogger<HatController> _logger;
        protected readonly ICurrentUser _currentUser;
        public HatController(IMediator mediator, ILogger<HatController> logger, ILoginService loginService)
        {
            _logger = logger;
            _mediator = mediator;
            _currentUser = loginService.GetCurrentUser();
        }
        protected IActionResult ForbidIfUserIdMismatch(IUserModel? userModel)
        {
            if (userModel == null)
            {
                _logger.LogWarning("User model is null.");
                return NotFound();
            }

            var currentUserId = _currentUser.Oid();
            if (userModel.UserId != currentUserId)
            {
                _logger.LogWarning("UserId mismatch: API caller {CurrentUserId} tried to access resource owned by {ResourceUserId}.", currentUserId, userModel.UserId);
                return Forbid();
            }

            return null;
        }
       
    }
}
