using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;
using Hat.Infrastructure.Identity.Memory;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryWishRepository : UserRepository, IWishRepository
    {
        public MemoryWishRepository(ICurrentUser currentUser) : base(currentUser)
        {
        }
        private static readonly Lazy<List<WishModel>> _wishes = new Lazy<List<WishModel>>(() =>
        {
           
            return new List<WishModel>
            {
                new WishModel { Id = Guid.NewGuid(), ProductId = MemoryProductRepository.Product1 }
            };
        });
        public static List<WishModel> Wishes => _wishes.Value;
        public Task<Guid> CreateWish(WishModel wish)
        {
            wish.Id = Guid.NewGuid();
            wish.UserId = _currentUser.Oid();
            Wishes.Add(wish);
            return Task.FromResult(wish.Id);
        }

        public Task DeleteWish(Guid productId)
        {
            foreach(var w in Wishes)
            {
                w.UserId = _currentUser.Oid();
            }
            var wishToDelete = Wishes.FirstOrDefault(w => w.ProductId == productId);
            if (wishToDelete != null)
            {
                Wishes.Remove(wishToDelete);
            }
            return Task.CompletedTask;
        }

        public Task<List<WishModel>> GetWishesByUser(Guid userId)
        {
            foreach (var w in Wishes)
            {
                w.UserId = _currentUser.Oid();
            }
            var wishesByUser = Wishes.Where(w => w.UserId == userId).ToList();
            if (wishesByUser.Count == 0)
            {
                return Task.FromResult(new List<WishModel>());
            }
            return Task.FromResult(wishesByUser);
        }

        public Task<WishModel?> GetWishByUserAndProduct(Guid userId, Guid productId)
        {
            foreach (var wish in Wishes)
            {
               wish.UserId = _currentUser.Oid();
            }
            return Task.FromResult(Wishes.SingleOrDefault(w => w.UserId == userId && w.ProductId == productId));
        }


        // This class is not used in the current context, but it can be implemented later if needed.
    }
}
