using MediatR;

namespace Hat.Domain.Commands
{
    public class RemoveProductOptionSelectionCommand : IRequest
    {
        public Guid Id { get; set; }
        public RemoveProductOptionSelectionCommand(Guid id)
        {
            Id = id;
        }
    }


}
