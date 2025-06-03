using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

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
                new WishModel { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), ProductId = MemoryProductRepository.Product1 }
            };
        });
        public static List<WishModel> Wishes => _wishes.Value;
        public Task<Guid> CreateWish(WishModel wish)
        {
            wish.Id = Guid.NewGuid();
            Wishes.Add(wish);
            return Task.FromResult(wish.Id);
        }

        public Task DeleteWish(Guid productId)
        {

            var wishToDelete = Wishes.FirstOrDefault(w => w.ProductId == productId);
            if (wishToDelete != null)
            {
                Wishes.Remove(wishToDelete);
            }
            return Task.CompletedTask;
        }

        public Task<List<WishModel>> GetWishesByUser(Guid userId)
        {
            var wishesByUser = Wishes.Where(w => w.UserId == userId).ToList();
            if (wishesByUser.Count == 0)
            {
                return Task.FromResult(new List<WishModel>());
            }
            return Task.FromResult(wishesByUser);
        }


        // This class is not used in the current context, but it can be implemented later if needed.
    }
}
