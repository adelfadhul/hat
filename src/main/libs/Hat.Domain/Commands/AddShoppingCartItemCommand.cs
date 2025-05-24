using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Commands
{
    public class AddShoppingCartItemCommand : IRequest
    {
        public ShoppingCartItemModel Item { get; set; }
        public AddShoppingCartItemCommand(ShoppingCartItemModel item)
        {
            Item = item;
        }
    }


}
