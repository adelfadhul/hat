using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class ProductOptionsByUserQueryHandler : IRequestHandler<ProductOptionsByProductQuery, List<ProductOptionModel>>
    {
        private readonly IProductOptionRepository _productOptionRepository;
        public ProductOptionsByUserQueryHandler(IProductOptionRepository productOptionRepository)
        {
            _productOptionRepository = productOptionRepository
                ?? throw new ArgumentException("ProductsOptionRepository must implement ICardRepository");
        }
        public async Task<List<ProductOptionModel>> Handle(ProductOptionsByProductQuery request, CancellationToken cancellationToken)
        {
            return await _productOptionRepository.GetProductOptionsByProduct(request.ProductId);
        }
    }
}
