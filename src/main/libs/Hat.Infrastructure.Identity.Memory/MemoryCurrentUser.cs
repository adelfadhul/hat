using Hat.Domain.Identity;
using System.Security.Claims;

namespace Hat.Infrastructure.Identity.Memory
{
    public class MemoryCurrentUser : ICurrentUser
    {
        public string Email()
       => "test@hat.com";

        public Task<bool> IsAdmin()
       => Task.FromResult(true);

        public string Name()
       => "Test User";

        private Guid? _oid;

        public Guid Oid()
        {
            if (_oid == null)
            {
                _oid = Guid.NewGuid();
            }
            return _oid.Value;
        }

        public void SetClaims(IEnumerable<Claim> claims)
        => _oid = claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value is string oidStr && Guid.TryParse(oidStr, out var oid) ? oid : Guid.NewGuid();

        public string Image()
       => "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Avatar.png";
    }
}
