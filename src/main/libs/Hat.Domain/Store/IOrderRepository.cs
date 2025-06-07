using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IOrderRepository
    {
        Task<OrderModel> GetOrderById(Guid orderId);
        Task CreateOrder(OrderModel order);
        Task UpdateOrder(OrderModel order);
        Task DeleteOrder(Guid orderId);
    }
}
