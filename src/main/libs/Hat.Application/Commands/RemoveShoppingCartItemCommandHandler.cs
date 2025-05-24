using Hat.Domain.Commands;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    public class RemoveShoppingCartItemCommandHandler : IRequestHandler<RemoveShoppingCartItemCommand>
    {
        private readonly IShoppingCartRepository _repository;
        public RemoveShoppingCartItemCommandHandler(IShoppingCartRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveShoppingCartItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteCartItem(request.Item.Id);
        }
    }
}
