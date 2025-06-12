using Hat.Domain.Commands;
using Hat.Domain.Enums;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        
        public CreateOrderCommandHandler(ICartRepository cartRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository ?? throw new ArgumentException("CartRepository must implement ICartRepository");
            _orderRepository = orderRepository ?? throw new ArgumentException("OrderRepository must implement IOrderRepository");
        }
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartById(request.Cart.Id);
            if (cart == null)
            {
                throw new Exception("Cart not found");
            }

            OrderModel order = new OrderModel()
            {
                BillingAddress = request.Cart.Address,
                Currency = "BHD",
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Draft
            };
            var orderId = await _orderRepository.CreateOrder(order);
            order.OrderItems = cart.CartItems.Select(item =>
            {
              
                return new OrderItemModel
                {
                    ProductId = item.ProductId,
                    Name = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Size = item.Size,
                    OrderId = orderId,
                    ImageUrl = item.ProductImageUrl,
                    Options = item.Options,
                };
            }).ToList();


            // Here you would typically create an order from the cart and save it to the database
            // For simplicity, we are just deleting the cart after creating the order
            await _cartRepository.DeleteCart(cart.Id);
        }
    }
}
