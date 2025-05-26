namespace Hat.Infrastructure.Persistance.SqlServer.Entities
{
    public class CustomerEntity
    {
        #region data
        public Guid Id { get;set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }

        #endregion

    }
}
