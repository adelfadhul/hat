using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class WishByUserAndProductQuery : IRequest<WishModel?>
    {
        public WishByUserAndProductQuery(Guid userId, Guid productId)
        {
            UserId = userId;
            ProductId = productId;
        }

        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
