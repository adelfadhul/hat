using Hat.Domain.Commands;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand>
    {
        private readonly ICartRepository _repository;
        public RemoveCartItemCommandHandler(ICartRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveItem(request.Id);
        }
    }
}
