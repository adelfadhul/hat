using Hat.Domain.Models;
using Hat.Domain.Repositories;

namespace Hat.Infrastructure.Persistance.SqlServer.Features
{
    public class SqlServerProductRepository : IProductRepository
    {
        public Task<List<ProductModel>> GetBestSettlingProducts()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetFeaturedProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel?> GetProductById(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetProductsByCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetProductsByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task GetTabPages()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetWhishListProducts(string brandId)
        {
            throw new NotImplementedException();
        }
    }
}
