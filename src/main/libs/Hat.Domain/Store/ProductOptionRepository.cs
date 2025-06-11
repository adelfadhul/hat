using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IProductOptionRepository
    {
        Task<List<ProductOptionModel>> GetProductOptionsByProduct(Guid productId);
        Task<List<ProductOptionModel>> GetProductOptionsByProducts(List<Guid> productIds);
        Task<ProductOptionModel?> GetProductOptionById(Guid productOptionId);
        Task<Guid> Create(ProductOptionModel model);
        Task Update(ProductOptionModel model);
        Task Delete(Guid productOptionId);
    }
}
