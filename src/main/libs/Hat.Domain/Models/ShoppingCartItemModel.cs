namespace Hat.Domain.Models
{
    public class ShoppingCartItemModel
    {
        #region data
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        public double ProductVatRate { get; set; } // Optional, if you want to track VAT separately
        public string ProductName { get; set; }


        public string BrandName { get; set; }
        public string ProductImageUrl { get; set; } 

        public string ProductDetails { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; } = 0.2; // 20% VAT by default
        public string Size { get; set; }
        #endregion

        #region rich
        public double Amount => Price * Qty;
        public double VatAmount => Amount * ProductVatRate;

      

        #endregion
    }
}
