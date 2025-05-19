using Hat.Domain.Models;

namespace Hat.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetProducts();
        Task<List<ProductModel>> GetProductsByCategory(string categoryId);
        Task<List<ProductModel>> GetBestSettlingProducts();
        Task<List<ProductModel>> GetFeaturedProducts();

        Task<List<ProductModel>> GetWhishListProducts(string brandId);
        Task<List<string>> GetBrands();
        Task GetTabPages();
    }
}
