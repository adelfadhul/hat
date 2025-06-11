using MediatR;

namespace Hat.Domain.Commands
{
    public class  RemoveCartItemCommand:IRequest
    {
        public Guid Id { get; set; }
        public RemoveCartItemCommand(Guid id)
        {
            Id = id;
        }
    }


}
