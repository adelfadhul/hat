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
        public ProductByIdQueryHandler(IProductRepository productRepository, IReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<ProductModel?> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductId);
            if (request.IsFull && product is not null)
                product.Reviews = await _reviewRepository.GetReviewsByProduct(product.Id);

            return product;

        }

    }
}
