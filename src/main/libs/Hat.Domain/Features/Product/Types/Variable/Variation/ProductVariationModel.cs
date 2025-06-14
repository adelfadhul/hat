namespace Hat.Domain.Features.Product.Types.Variable.Variation
{
    public class ProductVariationModel
    {

        #region data
        public Guid Id { get; set; }
        public Dictionary<string, string> Attributes { get; set; } = new();
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        #endregion
    }
}
