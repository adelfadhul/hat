using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class CartByUserQueryHandler : IRequestHandler<CartByUserQuery, CartModel?>
    {
        private readonly ICartRepository _cartRepository;
        public CartByUserQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository
                ?? throw new ArgumentException("CartRepository must implement ICartRepository");
            // Initialize any dependencies here, such as repositories or services
        }
        public async Task<CartModel?> Handle(CartByUserQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.GetCartByUser(request.UserId);
        }
    }
}
