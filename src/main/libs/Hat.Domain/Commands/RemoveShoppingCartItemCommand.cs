using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Commands
{
    public class  RemoveShoppingCartItemCommand:IRequest
    {
        public ShoppingCartItemModel Item { get; set; }
        public RemoveShoppingCartItemCommand(ShoppingCartItemModel item)
        {
            Item = item;
        }
    }


}
