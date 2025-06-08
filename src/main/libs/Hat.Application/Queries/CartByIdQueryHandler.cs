using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class CartByIdQueryHandler : IRequestHandler<CartByIdQuery, CartModel?>
    {
        private readonly ICartRepository _cartRepository;
        public CartByIdQueryHandler(ICartRepository cartRepository)
        {

            _cartRepository = cartRepository
                ?? throw new ArgumentException("CartRepository must implement ICartRepository");
        }
        public async Task<CartModel?> Handle(CartByIdQuery request, CancellationToken cancellationToken)
        {
            CartModel cart = await _cartRepository.GetCartById(request.Id);
            return cart;
        }
    }
}
