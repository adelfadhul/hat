using MediatR;

namespace Hat.Domain.Commands
{
    public class DeleteCardCommand:IRequest<bool>
    {
        public DeleteCardCommand(Guid cardId)
        {
            CardId = cardId;
        }
        public Guid CardId { get; init; }
    }   
}
