using Hat.Domain.Commands;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    public class RemoveShoppingCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand>
    {
        private readonly ICartRepository _repository;
        public RemoveShoppingCartItemCommandHandler(ICartRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteCartItem(request.Item.Id);
        }
    }
}
