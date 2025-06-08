using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryCartRepository : UserRepository, ICartRepository
    {
        private static readonly Lazy<List<CartModel>> _carts = new(() => new List<CartModel>
        {

        });
        public static List<CartModel> CARTS => _carts.Value;
        public MemoryCartRepository(ICurrentUser currentUser) : base(currentUser)
        {
        }

        public Task<Guid> AddCart(CartModel cart)
        {
            CARTS.Add(cart);
            return Task.FromResult(cart.Id);
        }

        public Task<CartModel> GetCartById(Guid cartId)
        {
            cartId = cartId == Guid.Empty ? CARTS.FirstOrDefault()?.Id ?? Guid.Empty : cartId;
            var cart = CARTS.FirstOrDefault(c => c.Id == cartId);
            if (cart == null)
            {
                throw new KeyNotFoundException($"Cart with ID {cartId} not found.");
            }
            return Task.FromResult(cart);
        }

        public Task AddItem(CartItemModel item)
        {
            CARTS.Where(c => c.Id == item.CartId)
                 .ToList()
                 .ForEach(c => c.CartItems.Add(item));
            return Task.CompletedTask;
        }



        public Task RemoveItem(Guid itemId)
        {
            CARTS.Where(c => c.CartItems.Any(i => i.Id == itemId))
                 .ToList()
                 .ForEach(c => c.CartItems.RemoveAll(i => i.Id == itemId));
            return Task.CompletedTask;
        }

        public Task DeleteCart(Guid Id)
        {
            var cart = CARTS.FirstOrDefault(c => c.Id == Id);
            if (cart == null)
            {
                throw new KeyNotFoundException($"Cart with ID {Id} not found.");
            }
            
            CARTS.RemoveAll(c => c.Id == Id);

            return Task.CompletedTask;
        }

        public Task<CartModel?> GetCartByUser(Guid userId)
        {
            return Task.FromResult(CARTS.FirstOrDefault(c => c.CustomerId == userId));
        }

        public Task<List<CartModel>> GetCarts()
        {
            return Task.FromResult(CARTS.ToList());
        }
    }
}
