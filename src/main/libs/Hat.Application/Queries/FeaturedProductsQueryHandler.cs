using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hat.Application.Queries
{
    public class FeaturedProductsQueryHandler : IRequestHandler<FeaturedProductsQuery, List<ProductModel>>
    {
        private readonly IProductRepository _productRepository;

        public FeaturedProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductModel>> Handle(FeaturedProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetFeaturedProducts();
        }
    }
}
