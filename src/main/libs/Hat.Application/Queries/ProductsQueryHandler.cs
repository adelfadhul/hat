using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class ProductsQueryHandler : IRequestHandler<ProductsQuery, List<ProductModel>>
    {
        private readonly IProductRepository _productRepository;

        public ProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductModel>> Handle(ProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProducts();
        }
    }
}
