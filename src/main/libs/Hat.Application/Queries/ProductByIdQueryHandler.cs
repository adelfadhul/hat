using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{

    internal class ProductByIdQueryHandler : IRequestHandler<ProductByIdQuery, ProductModel?>
    {
        private readonly IProductRepository _productRepository;

        public ProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductModel?> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductById(request.ProductId);
        }
    }
}
