using Hat.Domain.Enums;
using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IOrderRepository
    {
        Task<OrderModel> GetOrderById(Guid orderId);
        Task CreateOrder(OrderModel order);
        Task UpdateOrderStatus(Guid orderId,OrderStatus status);
        Task<List<OrderModel>> GetOrdersByUserId(Guid userId);

    }
}
