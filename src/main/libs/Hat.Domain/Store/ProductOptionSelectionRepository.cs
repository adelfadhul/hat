using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IProductOptionSelectionRepository
    {
        Task<List<ProductOptionSelectionModel>> GetProductOptionSelectionsByOption(Guid productId);
        Task<List<ProductOptionSelectionModel>> GetProductOptionSelectionsByProductIds(List<Guid> productIds);
        Task<ProductOptionSelectionModel?> GetProductOptionSelectionById(Guid productOptionSelectionId);
        Task<Guid> Create(ProductOptionSelectionModel model);
        Task Update(ProductOptionSelectionModel model);
        Task Delete(Guid productOptionSelectionId);
    }
}
