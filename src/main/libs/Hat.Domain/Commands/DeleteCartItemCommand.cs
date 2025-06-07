using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Commands
{
    public class  DeleteCartItemCommand:IRequest
    {
        public CartItemModel Item { get; set; }
        public DeleteCartItemCommand(CartItemModel item)
        {
            Item = item;
        }
    }


}
