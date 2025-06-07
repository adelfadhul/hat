using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryShoppingCartRepository :UserRepository, ICartRepository
    {
        private static readonly Lazy<List<CartItemModel>> _cartitems= new(() =>
        {
            var items = new List<CartItemModel>
            {
                new CartItemModel
                {
                    Id = Guid.NewGuid(),
                    Name = "BeoPlay Speaker",
                    BrandName = "Bang and Olufsen",
                    Price = 755,
                    ProductImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png",
                    ProductDetails = "High-quality wireless speaker with immersive sound.",
                    Qty = 10,
                    Size = "Standard"
                },
               
            };

           

            return items;
        });

        public MemoryShoppingCartRepository(ICurrentUser currentUser) : base(currentUser)
        {
        }

        private static List<CartItemModel> ITEMS=> _cartitems.Value;
        public async Task AddCartItem(CartItemModel item)
        {
            ITEMS.Add(item);
            await Task.CompletedTask;
        }

        public async Task ClearCart()
        {
             ITEMS.Clear();
             await Task.CompletedTask;
        }

        public async Task DeleteCartItem(Guid itemId)
        {
            ITEMS.RemoveAll(item => item.Id == itemId);
            await Task.CompletedTask;
        }

        public Task<List<CartItemModel>> GetCartItems()
        {
            return Task.FromResult(ITEMS);
        }
    }
}
