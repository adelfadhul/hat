using Hat.Domain.Features.Product.Models;
using Hat.Domain.Features.Product.Models.Queries;
using Hat.Domain.Features.Product.Store;
using MediatR;

namespace Hat.Application.Features.Product.Queries
{
    public class ProductListByCategoryQueryHandler : IRequestHandler<ProductListByCategoryQuery, IEnumerable<ProductModel>>
    {
        private readonly IProductRepository _productRepository;
        public ProductListByCategoryQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            // Constructor logic if needed
        }
        public async Task<IEnumerable<ProductModel>> Handle(ProductListByCategoryQuery request, CancellationToken cancellationToken)
        {
           return await _productRepository.GetProductsByCategory(request.CategoryId);
        }
    }
}
