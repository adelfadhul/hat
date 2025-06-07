using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public CartModel Cart { get; set; }
        public CreateOrderCommand(CartModel cart)
        {
            Cart = cart;
        }
    }


}
