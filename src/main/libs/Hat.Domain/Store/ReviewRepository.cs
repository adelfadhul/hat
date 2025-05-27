using Hat.Model;

namespace Hat.Domain.Store
{
    public interface IReviewRepository
    {
        Task<List<ReviewModel>> GetReviewsByProduct(Guid productId);
    }
}
