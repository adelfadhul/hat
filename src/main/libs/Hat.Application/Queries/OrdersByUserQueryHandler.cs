using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class OrdersByUserQueryHandler : IRequestHandler<OrdersByUserQuery, List<OrderModel>>
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersByUserQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderModel>> Handle(OrdersByUserQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrdersByUserId(request.UserId);
        }
    }
}
