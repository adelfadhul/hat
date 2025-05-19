using Hat.Domain.Models;
using Hat.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Hat.Infrastructure.Persistance.Http.Features
{
    public class HttpProductRepository : HttpRepository<ProductModel>, IProductRepository
    {
        public HttpProductRepository(HttpClient http, ILogger<HttpRepository<ProductModel>> logger) : base(http, logger)
        {
        }

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

        public async Task<List<ProductModel>> GetProducts()
        {
          return  await GetList("/api/products");
        }

        public Task<List<ProductModel>> GetProductsByCategory(string categoryId)
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
