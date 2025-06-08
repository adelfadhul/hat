using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class CartByUserQuery : IRequest<CartModel>
    {
        public Guid UserId { get; }
        public CartByUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
