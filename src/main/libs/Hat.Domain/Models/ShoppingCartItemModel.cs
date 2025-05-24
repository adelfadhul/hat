namespace Hat.Domain.Models
{
    public class ShoppingCartItemModel
    {
        #region data
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public string BrandName { get; set; }
        public string ProductImageUrl { get; set; } 

        public string ProductDetails { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        #endregion

        public double Amount => Price * Qty;
    }
}
