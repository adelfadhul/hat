using Hat.Domain.Commands;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    internal class DeleteWishCommandHandler : IRequestHandler<DeleteWishCommand, bool>
    {
        private readonly IWishRepository _wishRepository;
        public DeleteWishCommandHandler(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }
        public async Task<bool> Handle(DeleteWishCommand request, CancellationToken cancellationToken)
        {

            await _wishRepository.DeleteWish(request.WishId);
            return true;
        }
    }
}
