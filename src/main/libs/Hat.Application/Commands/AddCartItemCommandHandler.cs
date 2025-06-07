using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        public AddCartItemCommandHandler(ICartRepository repository, IProductRepository productRepository)
        {
            _cartRepository = repository;
            _productRepository = productRepository;
        }
        public async Task Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductId);
            CartItemModel cart = new CartItemModel
            {
                Name = product.Name,
                Price = product.Price,
                ProductImageUrl = product.ImageUrl,
                ProductDetails = product.Details,
                BrandName = product.BrandName,
                Size = request.Size,
                Quantity = request.Qty,
                ProductId = product.Id,
                ProductName = product.Name,
                CartId = request.CartId,

            };
            await _cartRepository.AddItem(cart);

        }
    }
}
