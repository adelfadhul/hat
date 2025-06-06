using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class OrdersQuery : IRequest<List<OrderModel>>
    {
    }
}
