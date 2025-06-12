using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateWishCommand : IRequest<Guid>
    {
        public CreateWishCommand(Guid userId, Guid productId)
        {
            UserId = userId;
            ProductId = productId;
        }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
