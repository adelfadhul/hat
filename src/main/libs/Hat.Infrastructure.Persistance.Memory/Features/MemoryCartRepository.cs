using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryCartRepository : UserRepository, ICartRepository
    {
        public MemoryCartRepository(ICurrentUser currentUser) : base(currentUser)
        {
        }

        public Task AddCartItem(CartItemModel item)
        {
            throw new NotImplementedException();
        }

        public Task ClearCart()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateCart(Guid UserId, string Address)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCartItem(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartItemModel>> GetCartItems()
        {
            throw new NotImplementedException();
        }
    }
}
