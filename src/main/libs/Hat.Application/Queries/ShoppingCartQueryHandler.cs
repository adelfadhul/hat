using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class ShoppingCartQueryHandler : IRequestHandler<ShoppingCartQuery, List<ShoppingCartItemModel>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartQueryHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<List<ShoppingCartItemModel>> Handle(ShoppingCartQuery request, CancellationToken cancellationToken)
        {
            return await _shoppingCartRepository.GetCartItems();
        }
    }


}
