using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hat.Application.Commands
{
    public class AddShoppingCartItemCommandHandler : IRequestHandler<AddShoppingCartItemCommand>
    {
        private readonly IShoppingCartRepository _repository;
        private readonly IProductRepository _productRepository;
        public AddShoppingCartItemCommandHandler(IShoppingCartRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }
        public async Task Handle(AddShoppingCartItemCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductId);
            ShoppingCartItemModel cart = new ShoppingCartItemModel
            {
                Name = product.Name,
                Price = product.Price,
                ProductImageUrl = product.ImageUrl,
                ProductDetails = product.Details,
                BrandName = product.BrandName,
                Size = request.Size,
                Qty = request.Qty,
                 ProductId= product.Id,
                ProductName = product.Name,
                 
            };
            await _repository.AddCartItem(cart);

        }
    }
}
