using Hat.Domain.Identity;
using System.Security.Claims;

namespace Hat.Infrastructure.Identity.Memory
{
  
        internal class AnonymousCurrentUser : ICurrentUser
        {
            private readonly Guid _oid;
            private readonly string _email;
            private readonly string _name;
            private readonly bool _isAdmin;
            private readonly string _image;

            public AnonymousCurrentUser(Guid oid, string email, string name, bool isAdmin, string image)
            {
                _oid = oid;
                _email = email;
                _name = name;
                _isAdmin = isAdmin;
                _image = image;
            }

            public Guid Oid() => _oid;
            public string Email() => _email;
            public string Name() => _name;
            public void SetClaims(IEnumerable<Claim> claims) { /* no-op for memory */ }
            public bool IsAdmin() => _isAdmin;
            public string Image() => _image;
        }
    
}
