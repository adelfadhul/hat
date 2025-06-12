using Hat.Domain.Identity;

namespace Hat.Infrastructure.Identity.Memory
{


    public class MemoryLoginService : ILoginService
    {
        private static readonly Lazy<List<ICurrentUser>> _users = new(() 
            
            => new List<ICurrentUser>
        {
            new AnonymousCurrentUser(
oid: Guid.Parse("11111111-1111-1111-1111-111111111111"),
                email: "alice@example.com",
                name: "Alice Smith",
                isAdmin: true,
                image: "alice.png"
            ),
            new AnonymousCurrentUser(
                oid:Guid.Parse("11111111-1111-1111-1111-111111111112"),
                email: "bob@example.com",
                name: "Bob Johnson",
                isAdmin: false,
                image: "bob.png"
            ),
            new AnonymousCurrentUser(
               oid:Guid.Parse("11111111-1111-1111-1111-111111111113"),
                email: "lina@example.com",
                name: "Lina Williams",
                isAdmin: false,
                image: "lina.png"
            )
        });

        public static List<ICurrentUser> USERS => _users.Value;
        public static Guid USER_Alice => USERS[0]?.Oid() ?? Guid.Empty;
        public static Guid USER_Bob => USERS[1]?.Oid() ?? Guid.Empty;
        public static Guid USER_Lina => USERS[2]?.Oid() ?? Guid.Empty;

        public static ICurrentUser CurrentUser;
        public MemoryLoginService()
        {

        }

        public ICurrentUser? Login(string email, string password)
        {
            // For memory implementation, password is ignored.
            // Find user by email (case-insensitive)
            var user = USERS.FirstOrDefault(u =>
                string.Equals(u.Email(), email, StringComparison.OrdinalIgnoreCase));
            CurrentUser = user;
           
            return user;
        }

        public ICurrentUser? LoginByOid(Guid oid)
        {
            var user = USERS.FirstOrDefault(u => u.Oid() == oid);
            return user;
        }

        public IEnumerable<ICurrentUser> GetAllUsers()
        {
            return USERS;
        }

        public ICurrentUser GetCurrentUser()
       => CurrentUser;
    }
}
