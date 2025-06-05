using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    internal class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Guid>
    {
        private readonly IInventoryRepository _inventoryRepository;

        public CreateInventoryCommandHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<Guid> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var id = await _inventoryRepository.Create(new InventoryModel
            {
                ProductColor = request.Color,
                Description = request.Description,
                Location = request.Location,
                ProductId = request.ProductId,
                ProductSize = request.Size,
                SKU = request.SKU,
            });

            return await Task.FromResult(id);   
        }
    }
}
