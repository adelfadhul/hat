using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IWishRepository
    {
        Task<List<WishModel>> GetWishesByUser(Guid userId);
        Task<WishModel?> GetWishByUserAndProduct(Guid userId, Guid productId);
        Task<Guid> CreateWish(WishModel wish);
        Task DeleteWish(Guid wishId);
    }
}
