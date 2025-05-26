
namespace Hat.Infrastructure.Persistance.SqlServer.Entities
{
    public class ReviewEntity
    {
        #region data
        public Guid Id { get; set; }
        public Guid ProductId { get;set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public float Rating { get; set; }

        #endregion
    }
}