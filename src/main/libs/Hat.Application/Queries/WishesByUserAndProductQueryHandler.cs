using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class WishesByUserAndProductQueryHandler : IRequestHandler<WishesByUserAndProductQuery, bool>
    {
        private readonly IWishRepository _wishRepository;
        public WishesByUserAndProductQueryHandler(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }
        public async Task<bool> Handle(WishesByUserAndProductQuery request, CancellationToken cancellationToken)
        {
            var wishes = await _wishRepository.GetWishes();
            return wishes.Any(w => w.UserId == request.UserId && w.ProductId == request.ProductId);
        }
    }
}
