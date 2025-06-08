using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface ICartRepository
    {
        Task<CartModel?> GetCartByUser(Guid userId);
        Task<CartModel> GetCartById(Guid cartId);
        Task AddItem(CartItemModel item);
        Task RemoveItem(Guid itemId);
        Task DeleteCart(Guid cartId);
        Task<List<CartModel>> GetCarts();
    }
}
