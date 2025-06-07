using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface ICartItemRepository
    {
        Task<List<CartItemModel>> GetCartItems();
        Task AddCartItem(CartItemModel item);
        Task DeleteCartItem(Guid itemId);
        Task ClearCart();
    }
}
