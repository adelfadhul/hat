using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class WishesByUserQueyHandler : IRequestHandler<WishesByUserQuery, List<WishModel>>
    {
        private readonly IWishRepository _wishRepository;
        public WishesByUserQueyHandler(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }
        public async Task<List<WishModel>> Handle(WishesByUserQuery request, CancellationToken cancellationToken)
        {
            var wishes = await _wishRepository.GetWishesByUser(request.UserId);
            return wishes ?? new List<WishModel>();
        }
    }
}
