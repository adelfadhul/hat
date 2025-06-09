using Hat.Domain.Identity;

namespace Hat.Infrastructure.Persistance.Memory
{
    public abstract class UserRepository
    {
        protected ICurrentUser _currentUser;
        public UserRepository(ILoginService loginService)
        {
            _currentUser = loginService.GetCurrentUser() ?? throw new ArgumentNullException(nameof(loginService), "Current user cannot be null");
        }
    }
}
