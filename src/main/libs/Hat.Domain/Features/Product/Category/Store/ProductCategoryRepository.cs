namespace Hat.Domain.Features.Product.Category.Store
{
    public interface ProductCategoryRepository
    {
        Task<List<ProductCategoryModel>> GetProductCategories();
        Task<List<ProductCategoryModel>> GetProductCategoriesByIds(List<Guid> guids);
        Task<ProductCategoryModel?> GetProductCategoryById(Guid productCategoryId);
        Task<Guid> Create(ProductCategoryModel model);
        Task Update(ProductCategoryModel model);
        Task Delete(Guid productCategoryId);
    }
}
