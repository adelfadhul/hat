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
            if (httpContext != null && httpContext.Request.Headers.TryGetValue("hat-user", out var userIdHeader))
            {
                if (userIdHeader.Count > 1)
                {
                    throw new UnauthorizedAccessException("Multiple user ID headers are not allowed.");
                }

                var userIdValue = userIdHeader.FirstOrDefault();
                if (!Guid.TryParse(userIdValue, out var userId))
                {
                    throw new UnauthorizedAccessException("Invalid user ID format.");
                }

                return userId;
            }
            throw new UnauthorizedAccessException("Missing user ID header.");
        }
    }
}
