using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    internal class CreateWishCommandHandler : IRequestHandler<CreateWishCommand, Guid>
    {
        private readonly IWishRepository _wishRepository;
        public CreateWishCommandHandler(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }
        public async Task<Guid> Handle(CreateWishCommand request, CancellationToken cancellationToken)
        {
            var id = await _wishRepository.CreateWish(new WishModel
            {
                UserId = request.UserId,
                ProductId = request.ProductId
            });

            return await Task.FromResult(id);
        }
    }
}
