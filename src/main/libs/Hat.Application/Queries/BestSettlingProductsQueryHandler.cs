using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hat.Application.Queries
{
    public class BestSettlingProductsQueryHandler : IRequestHandler<BestSettlingProductsQuery, List<ProductModel>>
    {
        private readonly IProductRepository _productRepository;

        public BestSettlingProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductModel>> Handle(BestSettlingProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetBestSettlingProducts();
        }
    }
}
