using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class BestSellingProductsQueryHandler : IRequestHandler<BestSellingProductsQuery, List<ProductModel>>
    {
        private readonly IProductRepository _productRepository;

        public BestSellingProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductModel>> Handle(BestSellingProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetBestSettlingProducts();
        }
    }
}
