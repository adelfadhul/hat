using MediatR;

namespace Hat.Domain.Commands
{
    public class DeleteWishCommand : IRequest<bool>
    {
        public DeleteWishCommand(Guid wishId)
        {
            WishId = wishId;
        }
        public Guid WishId { get; init; }
    }
}
