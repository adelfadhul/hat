using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    internal class AddProductOptionCommandHandler : IRequestHandler<AddProductOptionCommand, Guid>
    {
        private readonly IProductOptionRepository _productOptionRespository;
        public AddProductOptionCommandHandler(IProductOptionRepository productOptionRespository)
        {
            _productOptionRespository = productOptionRespository;
        }
        public async Task<Guid> Handle(AddProductOptionCommand request, CancellationToken cancellationToken)
        {
            return await _productOptionRespository.Create(new ProductOptionModel
            {

                ProductId = request.ProductId,
                Name = request.Name,
                ValueType = request.ValueType,

            });

           
        }
    }
}
