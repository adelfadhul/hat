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
        protected readonly IUserContext _userContext;
        public HatController(IMediator mediator, ILogger<HatController> logger, IUserContext userContext)
        {
            _logger = logger;
            _mediator = mediator;
            _userContext = userContext;
        }
        protected IActionResult ForbidIfUserIdMismatch(IUserModel? userModel)
        {
            var userId = _userContext.GetUserId();


            if (userModel?.UserId != userId)
            {
                _logger.LogWarning("UserId mismatch: API caller {CurrentUserId} tried to access resource owned by {ResourceUserId}.", userId, userModel.UserId);
                return Forbid();
            }

            return null;
        }

      


    }
}
