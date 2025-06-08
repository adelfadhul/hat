using Hat.Domain.Identity;
using System.Security.Claims;

namespace Hat.Infrastructure.Identity.Memory
{
   
    public class MemoryCurrentUser : ICurrentUser
    {
        public string Email()
       => "test@hat.com";

        public bool IsAdmin()=>true;

        public string Name()
       => "Test User";

        private Guid? _oid;

        public static Guid USERID => Guid.Parse("00000000-0000-0000-0000-000000000001");
        public Guid Oid()
        {
            if (_oid == null)
            {
                _oid = USERID;
            }
            return _oid.Value;
        }

        public void SetClaims(IEnumerable<Claim> claims)
        => _oid = claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value is string oidStr && Guid.TryParse(oidStr, out var oid) ? oid : Guid.NewGuid();

        public string Image()
       => "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Avatar.png";
    }
}
