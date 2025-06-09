namespace Hat.Domain.Identity
{
    public interface ILoginService
    {
       ICurrentUser GetCurrentUser();

        IEnumerable<ICurrentUser> GetAllUsers();
        ICurrentUser? Login(string email, string password);
        ICurrentUser? LoginByOid(Guid oid);
    }
}