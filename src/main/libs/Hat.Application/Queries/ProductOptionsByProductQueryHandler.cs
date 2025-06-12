using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class ProductOptionsByProductQueryHandler : IRequestHandler<ProductOptionsByProductQuery, List<ProductOptionModel>>
    {
        private readonly IProductOptionRepository _productOptionRepository;
        public ProductOptionsByProductQueryHandler(IProductOptionRepository productOptionRepository)
        {
            _productOptionRepository = productOptionRepository
                ?? throw new ArgumentException("ProductOptionRepository must implement IProductOptionRepository");
        }
        public async Task<List<ProductOptionModel>> Handle(ProductOptionsByProductQuery request, CancellationToken cancellationToken)
        {
            return await _productOptionRepository.GetProductOptionsByProduct(request.ProductId);
        }
    }
}
