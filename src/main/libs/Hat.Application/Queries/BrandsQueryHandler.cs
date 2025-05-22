using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class BrandsQueryHandler : IRequestHandler<BrandsQuery, List<string>>
    {
        private readonly IProductRepository _productRepository;

        public BrandsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<string>> Handle(BrandsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetBrands();
        }
    }
}
