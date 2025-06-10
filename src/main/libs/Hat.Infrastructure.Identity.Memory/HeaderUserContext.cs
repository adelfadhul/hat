using Hat.Domain.Identity;
using Microsoft.AspNetCore.Http;

namespace Hat.Infrastructure.Identity.Memory
{
    public class HeaderUserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HeaderUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (!httpContext.Request.Headers.TryGetValue("hat-user", out var userIdHeader))
            {
                // throw new UnauthorizedAccessException("Missing user ID header.");
            }

            if (!Guid.TryParse(userIdHeader, out var userId)) {
                //       throw new UnauthorizedAccessException("Invalid user ID format.");     
            }


            return userId;
        }
    }
}
