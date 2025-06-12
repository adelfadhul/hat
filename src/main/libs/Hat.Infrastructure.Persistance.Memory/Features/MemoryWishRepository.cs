using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;
using Hat.Infrastructure.Identity.Memory;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryWishRepository :  IWishRepository
    {
        public MemoryWishRepository()
        {
        }
        private static readonly Lazy<List<WishModel>> _wishes = new Lazy<List<WishModel>>(() =>
        {
           
            return new List<WishModel>
            {
                new WishModel { Id = Guid.NewGuid(), ProductId = MemoryProductRepository.PRODUCT_BeoPlaySpeaker, UserId=MemoryLoginService.USER_Alice }
            };
        });
        public static List<WishModel> Wishes => _wishes.Value;
        public Task<Guid> CreateWish(WishModel wish)
        {
            wish.Id = Guid.NewGuid();
            Wishes.Add(wish);
            if(wish.UserId == Guid.Empty)
            {
                throw new ArgumentException("UserId cannot be empty", nameof(wish.UserId));
            }
            return Task.FromResult(wish.Id);
        }

        public Task DeleteWish(Guid wishId)
        {
           
            var wishToDelete = Wishes.FirstOrDefault(w => w.Id == wishId);
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

        public Task<WishModel?> GetWishByUserAndProduct(Guid userId, Guid productId)
        {
           
            return Task.FromResult(Wishes.SingleOrDefault(w => w.UserId == userId && w.ProductId == productId));
        }

        public Task<WishModel?> GetWishById(Guid id)
        {
            return Task.FromResult(Wishes.SingleOrDefault(w => w.Id == id));
        }


        // This class is not used in the current context, but it can be implemented later if needed.
    }
}
