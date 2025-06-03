using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class WishesByUserAndProductQueryHandler : IRequestHandler<WisheByUserAndProductQuery, WishModel?>
    {
        private readonly IWishRepository _wishRepository;
        public WishesByUserAndProductQueryHandler(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }
        public async Task<WishModel?> Handle(WisheByUserAndProductQuery request, CancellationToken cancellationToken)
        {
            return await _wishRepository.GetWishByUserAndProduct(request.UserId,request.ProductId);
        
        }
    }
}
