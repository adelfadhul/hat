using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class WisheByUserAndProductQuery : IRequest<WishModel?>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
