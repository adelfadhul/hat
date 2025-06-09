using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class WishByIdQuery : IRequest<WishModel?>
    {
        public WishByIdQuery(Guid wishId)
        {
            WishId = wishId;
        }
        public Guid WishId { get; set; }
    }
}
