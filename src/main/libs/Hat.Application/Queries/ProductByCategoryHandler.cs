using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class ProductByCategoryHandler:IRequestHandler<ProductsByCategoryQuery, List<ProductModel>>
    {
        private readonly IProductRepository _productRepository;
        public ProductByCategoryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductModel>> Handle(ProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsByCategory(request.CategoryId);
        }
    }
}
