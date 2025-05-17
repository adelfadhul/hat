using Hat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hat.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetProducts();
    }
}
