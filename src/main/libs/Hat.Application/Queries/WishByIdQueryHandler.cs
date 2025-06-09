using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class WishByIdQueryHandler : IRequestHandler<WishByIdQuery, WishModel?>
    {
        private readonly IWishRepository _wishRepository;
        public WishByIdQueryHandler(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }
        public async Task<WishModel?> Handle(WishByIdQuery request, CancellationToken cancellationToken)
        {
            return await _wishRepository.GetWishById(request.WishId);
        }
    }
}
