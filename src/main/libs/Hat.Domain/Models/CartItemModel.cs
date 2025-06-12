namespace Hat.Domain.Models
{
    public class CartItemModel
    {
        #region data
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        public Guid CartId { get; set; } 

        public decimal ProductVatRate { get; set; } // Optional, if you want to track VAT separately
        public string ProductName { get; set; }

        public string ProductColor { get; set; } // Optional, if you want to track color separately
        public string ProductSize { get; set; } // Optional, if you want to track size separately
        public string BrandName { get; set; }
        public string ProductImageUrl { get; set; } 

        public string ProductDetails { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; } = 0m; // 20% VAT by default
        public string Size { get; set; }

        public Dictionary<string, string> Options { get; set; }
       
        #endregion

        #region rich
        public decimal Amount => Price * Quantity;
        public decimal VatAmount => Amount * ProductVatRate;

        #endregion
    }
}
