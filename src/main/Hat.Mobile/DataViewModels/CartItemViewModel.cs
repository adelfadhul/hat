using Hat.Domain.Models;
using Hat.Mobile.ViewModels;

namespace Hat.DataViewModels
{
    public class CartItemViewModel : BaseViewModel
    {
        public CartItemViewModel()
        {
        }
        public CartItemViewModel(ShoppingCartItemModel domainModel)
        {
            Id = domainModel.Id;
            Name = domainModel.Name;
            ProductImageUrl = domainModel.ProductImageUrl;
            BrandName = domainModel.BrandName;
            Price = domainModel.Price;
            ProductDetials = domainModel.ProductDetails; 
            Qty = domainModel.Qty;
            Size = domainModel.Size;
        }

        public Guid Id { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDetials { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }

        public double Qty { get; set; } = 1;

        public string Size { get; set; }
       
      
       

      


    }
}
