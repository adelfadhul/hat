using Hat.Domain.Models;
using Hat.Domain.Repositories;

namespace Hat.Infrastructure.Persistance.SqlServer.Features
{
    public class SqlServerProductRepository : IProductRepository
    {
        public Task<List<ProductModel>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
