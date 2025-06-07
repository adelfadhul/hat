using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface ICartRepository
    {
        Task<CartModel> GetCartById(Guid cartId);
        Task<List<CartItemModel>> GetCartItems();
        Task AddCartItem(CartItemModel item);
        Task DeleteCartItem(Guid itemId);
        Task ClearCart();

        Task<Guid> CreateCart(Guid UserId, string Address);
    }
}
