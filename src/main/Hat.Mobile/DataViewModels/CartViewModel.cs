using Hat.Domain.Models;
using Hat.Mobile.ViewModels;

namespace Hat.DataViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public CartViewModel()
        {

        }
        public Guid Id { get; set; }
        public string Address { get; set; } // Optional, if you want to track the delivery address for the cart

        public decimal TotalPrice { get; set; }

        public List<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();
        public CartViewModel(CartModel data)
        {
            Id = data.Id;
            Address = data.Address;
            TotalPrice = data.TotalPrice;
            if (data.CartItems != null)
            {
                foreach (var item in data.CartItems)
                {
                    CartItems.Add(new CartItemViewModel(item));
                }
            }
        }
    }
}
