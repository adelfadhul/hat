using MediatR;

namespace Hat.Domain.Commands
{
    public class DeleteCartCommand : IRequest
    {
        public Guid CartId { get; set; }
        public DeleteCartCommand(Guid cartId)
        {
            CartId = cartId;
        }
    }


}
