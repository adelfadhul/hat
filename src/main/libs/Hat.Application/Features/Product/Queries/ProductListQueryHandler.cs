using Hat.Domain.Features.Product.Models;
using Hat.Domain.Features.Product.Models.Queries;
using Hat.Domain.Features.Product.Store;
using MediatR;

namespace Hat.Application.Features.Product.Queries
{
    public class ProductListQueryHandler : IRequestHandler<ProductListQuery, IEnumerable<ProductModel>>
    {
        private readonly IProductRepository _productRepository;
        public ProductListQueryHandler(IProductRepository productRepository)
        {
            // Initialize any dependencies here if needed
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductModel>> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProducts();
        }
    }
}
