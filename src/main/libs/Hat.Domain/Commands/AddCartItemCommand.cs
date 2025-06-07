using MediatR;

namespace Hat.Domain.Commands
{
    public class AddCartItemCommand : IRequest
    {
        public Guid CartId { get; set; }
        public  Guid ProductId { get; set; }
        public  int Qty { get; set; }
        public string Size { get; set; }
        public AddCartItemCommand(Guid productid, int qty, string size)
        {
            ProductId = productid;
            Qty = qty;
            Size = size;
        }
    }


}
