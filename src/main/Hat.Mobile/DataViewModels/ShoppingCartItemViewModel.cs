using Hat.Domain.Models;
using Hat.Mobile.ViewModels;

namespace Hat.DataViewModels
{
    public class ShoppingCartItemViewModel : BaseViewModel
    {
        public ShoppingCartItemViewModel()
        {
        }
        public ShoppingCartItemViewModel(CartItemModel domainModel)
        {
            Id = domainModel.Id;
            Name = domainModel.Name;
            ProductImageUrl = domainModel.ProductImageUrl;
            BrandName = domainModel.BrandName;
            Price = domainModel.Price;
            ProductDetails = domainModel.ProductDetails;
            Qty = domainModel.Qty;
            Size = domainModel.Size;
            Amount = domainModel.Amount;
            Vat = domainModel.VatAmount;
        }
        public Guid Id { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDetails { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public double Qty { get; set; } = 1;
        public string Size { get; set; }

        public decimal Amount { get; init; }
        public decimal Vat { get; init; }
    }
}
