using Hat.Domain.Commands;
using Hat.Domain.Enums;
using Hat.Domain.Payment;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    public class FinalizeOrderPaymentCommandHandler : IRequestHandler<FinalizeOrderPaymentCommand>
    {
        private readonly IOrderRepository _orderRepository;
        public FinalizeOrderPaymentCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentException("OrderRepository must implement IOrderRepository");
        }
        public async Task Handle(FinalizeOrderPaymentCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderById(request.OrderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            if (request.PaymentResult.Status == PaymentStatus.Completed)
                await _orderRepository.UpdateOrderStatus(request.OrderId,OrderStatus.Paid);


        }
    }
}
