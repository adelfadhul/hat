namespace Hat.Infrastructure.Persistance.SqlServer.Entities
{
    public class DeliveryTypeEntity
    {
        #region data
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsSelected { get; set; }

        #endregion

    }
}
