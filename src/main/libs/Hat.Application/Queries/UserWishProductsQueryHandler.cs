using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class UserWishProductsQueryHandler : IRequestHandler<UserWishProductsQuery, List<ProductModel>>
    {
        private readonly IWishRepository _wishRepository;
        private readonly IProductRepository _productRepository;
        public UserWishProductsQueryHandler(IWishRepository wishRepository, IProductRepository productRepository)
        {
            _wishRepository = wishRepository;
            _productRepository = productRepository;
        }
        public async Task<List<ProductModel>> Handle(UserWishProductsQuery request, CancellationToken cancellationToken)
        {
            var wishes = await _wishRepository.GetWishesByUser(request.UserId);
            var wishIdes = wishes?.Select(w => w.ProductId).ToList() ?? new List<Guid>();
            var products = await _productRepository.GetProductsByIds(wishIdes);
            return products ?? new List<ProductModel>();
        }
    }
}
