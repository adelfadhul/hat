using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class OrdersByUserQuery : IRequest<List<OrderModel>>
    {
        public Guid UserId { get; set; }
        public OrdersByUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
