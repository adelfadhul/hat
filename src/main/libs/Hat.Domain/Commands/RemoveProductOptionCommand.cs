using MediatR;

namespace Hat.Domain.Commands
{
    public class RemoveProductOptionCommand : IRequest
    {
        public Guid Id { get; set; }
        public RemoveProductOptionCommand(Guid id)
        {
            Id = id;
        }
    }


}
