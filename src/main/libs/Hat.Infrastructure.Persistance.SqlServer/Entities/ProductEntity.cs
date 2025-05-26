namespace Hat.Infrastructure.Persistance.SqlServer.Entities
{
    public class ProductEntity
    {

        #region data
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }
        public Guid CustomerId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public double Qty { get; set; }
        public bool IsAvailable { get; set; }

        public string ColorText { get; set; }
        public string SizesText { get; set; }

        public List<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
        #endregion

        

    }
}
