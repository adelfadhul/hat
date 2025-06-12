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
            var cart = new CartModel()
            {
                UserId = request.UserId,
                CartItems = request.CartItems,
                 
            };
            var cartId=await _cartRepository.CreateCart(cart);
            var cartModel= await _cartRepository.GetCartById(cartId);
            await _cartRepository.AddItem(cartModel.CartItems);
            return cart;
        }
    }
}
