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

        public async Task<List<ProductModel>> GetProducts()
        {
          return  await GetList("/api/products");
        }
    }
}
