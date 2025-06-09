using Hat.Domain.Identity;
using System.Security.Claims;

namespace Hat.Infrastructure.Identity.Memory
{
   
    public class MemoryCurrentUser : ICurrentUser
    {
        public MemoryCurrentUser(Guid oid)
        {
            _oid = Guid.Empty;
        }
        public string Email();

        public bool IsAdmin()=>true;

        public string Name();

        private Guid? _oid;

       // public static Guid USERID => Guid.Parse("00000000-0000-0000-0000-000000000001");
        public Guid Oid()
        {
            if (!(oid == Guid.Empty || oid==null))
            {
                _oid = oid;
            }
            return _oid ??= Guid.NewGuid();
         
        }

       
    }
}
