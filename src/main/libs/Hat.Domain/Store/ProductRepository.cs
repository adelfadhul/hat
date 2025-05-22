using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetProducts();
        Task<List<ProductModel>> GetProductsByCategory(Guid categoryId);
        Task<List<ProductModel>> GetBestSettlingProducts();
        Task<List<ProductModel>> GetFeaturedProducts();

        Task<List<ProductModel>> GetWhishListProducts(string brandId);
        Task<List<string>> GetBrands();
        Task<ProductModel?> GetProductById(Guid productId);
        Task GetTabPages();
    }
}
