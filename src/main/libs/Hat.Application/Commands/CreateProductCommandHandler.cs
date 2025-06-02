using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.Create(new ProductModel
            {
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
