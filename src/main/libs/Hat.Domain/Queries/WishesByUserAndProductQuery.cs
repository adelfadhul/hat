using MediatR;

namespace Hat.Domain.Queries
{
    public class WishesByUserAndProductQuery : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
