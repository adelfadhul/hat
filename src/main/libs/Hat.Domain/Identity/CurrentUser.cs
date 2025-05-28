using System.Security.Claims;

namespace Hat.Domain.Identity
{
    public interface ICurrentUser
    {

        Guid Oid();

        string Email();



        string Name();

        void SetClaims(IEnumerable<Claim> claims);

        Task<bool> IsAdmin();
        string Image();
    }
}
