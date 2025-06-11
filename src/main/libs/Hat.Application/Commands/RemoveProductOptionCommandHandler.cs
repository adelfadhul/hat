using Hat.Domain.Commands;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    public class RemoveProductOptionCommandHandler : IRequestHandler<RemoveProductOptionCommand>
    {
        private readonly IProductOptionRepository _repository;
        public RemoveProductOptionCommandHandler(IProductOptionRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveProductOptionCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
        }
    }
}
