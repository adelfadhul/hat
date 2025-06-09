using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, CartModel>
    {
        private readonly ICartRepository _cartRepository;
        public CreateCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<CartModel> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = new CartModel() { 
              UserId = request.UserId,
            };
            await _cartRepository.CreateCart(cart);
            return cart;
        }
    }
}
