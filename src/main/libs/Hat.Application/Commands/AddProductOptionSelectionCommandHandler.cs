using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{


    internal class AddProductOptionSelectionCommandHandler : IRequestHandler<AddProductOptionSelectionCommand, Guid>
    {
        private readonly IProductOptionSelectionRepository _productOptionSelectionRepository;
        public AddProductOptionSelectionCommandHandler(IProductOptionSelectionRepository productOptionSelectionRepository)
        {
            _productOptionSelectionRepository = productOptionSelectionRepository;
        }
        public async Task<Guid> Handle(AddProductOptionSelectionCommand request, CancellationToken cancellationToken)
        {
            return await _productOptionSelectionRepository.Create(new ProductOptionSelectionModel
            {
                 
                ProductOptionId = request.ProductOptionId,
                Value = request.Value
            });
        }
    }
}
