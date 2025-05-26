namespace Hat.Infrastructure.Persistance.SqlServer.Entities
{
    public class CategoryEntity
    {

        #region data
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        #endregion
     
    }
}
