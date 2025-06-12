using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class ProductOptionByIdQueryHandler : IRequestHandler<ProductOptionByIdQuery, ProductOptionModel?>
    {
        private readonly IProductOptionRepository _productOptionRepository;
        public ProductOptionByIdQueryHandler(IProductOptionRepository productOptionRepository)
        {
            _productOptionRepository = productOptionRepository
                ?? throw new ArgumentException("ProductsOptionRepository must implement ICardRepository");
        }
        public async Task<ProductOptionModel?> Handle(ProductOptionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productOptionRepository.GetProductOptionById(request.Id);
        }
    }
}
