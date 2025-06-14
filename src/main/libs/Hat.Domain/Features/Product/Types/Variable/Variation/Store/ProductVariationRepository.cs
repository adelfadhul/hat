namespace Hat.Domain.Features.Product.Types.Variable.Variation.Store
{
    public interface ProductVariationRepository
    {
        Task<List<ProductVariationModel>> GetProductVariationsByProduct(Guid productId);
        Task<List<ProductVariationModel>> GetProductVariationsByProducts(List<Guid> productIds);
        Task<ProductVariationModel?> GetProductVariationById(Guid productVariationId);
        Task<Guid> Create(ProductVariationModel model);
        Task Update(ProductVariationModel model);
        Task Delete(Guid productVariationId);
    }
}
