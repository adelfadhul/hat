using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateWishCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
