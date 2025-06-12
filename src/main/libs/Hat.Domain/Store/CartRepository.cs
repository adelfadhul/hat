using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface ICartRepository
    {
        Task<CartModel?> GetCartByUser(Guid UserId);
        Task<CartModel> GetCartById(Guid cartId);
        Task<Guid> CreateCart(CartModel cart);
        Task AddItem(List<CartItemModel> item);
        Task AddItem(CartItemModel item);
        Task RemoveItem(Guid itemId);
        Task DeleteCart(Guid cartId);
        Task<List<CartModel>> GetCarts();
    }
}
