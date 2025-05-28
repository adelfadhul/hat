using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class ProductByIdQueryHandler : IRequestHandler<ProductByIdQuery, ProductModel?>
    {
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IVatRepository _vatRepository;

        public ProductByIdQueryHandler(IProductRepository productRepository, IReviewRepository reviewRepository, IVatRepository vatRepository)
        {
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
            _vatRepository = vatRepository;
        }

        public async Task<ProductModel?> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductId);
            if (product is null) return null;

            var vat = await _vatRepository.GetVat(product?.VatId ?? Guid.Empty);
            if(vat is not null)
            {
                product.Vat = vat;
            }
           

            if (request.IsFull && product is not null)
                product.Reviews = await _reviewRepository.GetReviewsByProduct(product.Id);

            return product;

        }

    }
}
