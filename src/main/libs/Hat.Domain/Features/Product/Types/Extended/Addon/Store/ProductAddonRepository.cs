namespace Hat.Domain.Features.Product.Types.Extended.Addon.Store
{
    public interface IProductAddonRepository
    {
        Task<List<ProductAddonModel>> GetProductAddonsByProduct(Guid productId);
        Task<ProductAddonModel?> GetProductAddonById(Guid productAddonId);
        Task<Guid> Create(ProductAddonModel model);
        Task Update(ProductAddonModel model);
        Task Delete(Guid productAddonId);
        Task<List<ProductAddonModel>> GetProductAddonsByProducts(List<Guid> productIds);

    }
}
