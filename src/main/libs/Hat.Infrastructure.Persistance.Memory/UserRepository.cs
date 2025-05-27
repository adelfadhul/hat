using Hat.Domain.Identity;

namespace Hat.Infrastructure.Persistance.Memory
{
    public abstract class UserRepository
    {
        protected ICurrentUser _currentUser;
        public UserRepository(ICurrentUser currentUser)
        {
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser), "Current user cannot be null");
        }
    }
}
