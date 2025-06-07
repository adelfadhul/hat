using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class ShoppingCartQueryHandler : IRequestHandler<ShoppingCartQuery, List<CartItemModel>>
    {
        private readonly ICartRepository _shoppingCartRepository;
        public ShoppingCartQueryHandler(ICartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<List<CartItemModel>> Handle(ShoppingCartQuery request, CancellationToken cancellationToken)
        {
            return await _shoppingCartRepository.GetCartItems();
        }
    }


}
