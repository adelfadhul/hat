using Hat.Domain.Commands;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    public class RemoveProductOptionSelectionCommandHandler : IRequestHandler<RemoveProductOptionSelectionCommand>
    {
        private readonly IProductOptionSelectionRepository _repository;
        public RemoveProductOptionSelectionCommandHandler(IProductOptionSelectionRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveProductOptionSelectionCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
        }
    }
}
