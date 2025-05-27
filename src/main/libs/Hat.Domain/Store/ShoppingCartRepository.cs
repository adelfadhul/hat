using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IShoppingCartRepository
    {
        Task<List<ShoppingCartItemModel>> GetCartItems();
        Task AddCartItem(ShoppingCartItemModel item);
        Task DeleteCartItem(Guid itemId);
        Task ClearCart();
    }
}
