using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    internal class AddProductCommandHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public AddProductCommandHandler(IProductRepository productRepository) {
            _productRepository = productRepository;
        }
        public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
         await  _productRepository.Create(new ProductModel {
               BrandName = request.BrandName,
               CategoryId = request.CategoryId,
               Details = request.Details,
               ImageUrl = request.ImageUrl,
               Name = request.Name,
               Price = request.Price,
               CustomerId = request.CustomerId,
               UserId = request.UserId,
               VatId = request.VatId,
           });
        }
    }
}
