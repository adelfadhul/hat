using MediatR;

namespace Hat.Domain.Commands
{
    public class AddShoppingCartItemCommand : IRequest
    {
        public  Guid ProductId { get; set; }
        public  int Qty { get; set; }
        public string Size { get; set; }
        public AddShoppingCartItemCommand(Guid productid, int qty, string size)
        {
            ProductId = productid;
            Qty = qty;
            Size = size;
        }
    }


}
