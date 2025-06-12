using Hat.Domain.Enums;
using Hat.Domain.Models;
using Hat.Domain.Store;
using Hat.Infrastructure.Identity.Memory;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryOrderRepository :    IOrderRepository
    {
        public MemoryOrderRepository()    
        {
        }

        public static Guid Order1 => ORDERS[0].Id;
        public static Guid Order2 => ORDERS[1].Id;
        public static Guid Order3 => ORDERS[2].Id;
        public static Guid Order4 => ORDERS[3].Id;

        private static Lazy<List<OrderModel>> _orders = new(() =>
        {

            var tracks = new List<OrderModel>
        {
            new OrderModel
            {
                Id=Guid.NewGuid(),
                 UserId= MemoryLoginService.USER_Alice,
                OrderDate= new DateTime(2022,9,1,0,0,0),
                Name = "OD - 424923192 - N",
                Price = "$4500",
                Status = OrderStatus.Shipped,
                ImageUrls = string.Join(",",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png"
                )
            },
            new OrderModel
            {
                 Id=Guid.NewGuid(),
                 UserId= MemoryLoginService.USER_Bob,
                OrderDate= new DateTime(2022,9,1,0,0,0),
                Name = "OD - 424923192 - N",
                Price = "$500",
                Status =  OrderStatus.Shipped,
                ImageUrls = string.Join(",",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png"
                )
            },
            new OrderModel
            {
                 Id=Guid.NewGuid(),
                 UserId= MemoryLoginService.USER_Lina,
                OrderDate= new DateTime(2022,9,1,0,0,0),
                Name = "OD - 424923192 - N",
                Price = "$700",
                Status = OrderStatus.Shipped,
                ImageUrls = string.Join(",",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png"
                )
            },
            new OrderModel
            {
                 Id=Guid.NewGuid(),
                 UserId= MemoryLoginService.USER_Alice,
                OrderDate = new DateTime(2023, 5, 2, 0, 0, 0),
                Name = "OD - 424923192 - N",
                Price = "$1500",
                Status = OrderStatus.Shipped,
                ImageUrls = string.Join(",",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png"
                )
            },
            new OrderModel
            {
                 Id=Guid.NewGuid(),
                 UserId= MemoryLoginService.USER_Bob,
                 OrderDate = new DateTime(2023, 5, 2, 0, 0, 0),
                Name = "OD - 424923192 - N",
                Price = "$2700",
                Status = OrderStatus.Shipped,
                ImageUrls = string.Join(",",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Apple.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png"
                )
            }
        };
            return tracks;
        });

        public static List<OrderModel> ORDERS => _orders.Value;

        public Task<OrderModel> GetOrderById(Guid orderId)
        {
            return Task.FromResult(ORDERS.FirstOrDefault(o => o.Id == orderId) ?? throw new KeyNotFoundException($"Order with ID {orderId} not found."));
        }

        public Task<Guid> CreateOrder(OrderModel order)
        {
            ORDERS.Add(order);
            order.Id = Guid.NewGuid();
            order.OrderDate = DateTime.UtcNow;
            order.Status = OrderStatus.Draft; // Default status when creating an order
            order.OrderNumber = $"OD-{order.Id:N}"; // Generate a unique order number
            order.CustomerId = order.UserId.ToString(); // Assuming UserId is a Guid, convert to string
            order.Currency = "BHD"; // Default currency, can be changed as needed
            order.PaymentStatus = "Pending"; // Default payment status
            order.PaymentGateway = "FakePayment"; // Default payment gateway, can be changed as needed
            order.PaymentGatewayTransactionId = Guid.NewGuid().ToString(); // Generate a fake transaction ID
            order.TotalAmount = 0; // Initialize total amount, should be calculated based on order items
            order.ShippingMethod = "Standard"; // Default shipping method
            order.ShippingCost = "0"; // Default shipping cost, can be changed as needed
            order.TaxAmount = "0"; // Default tax amount, can be changed as needed
            order.DiscountAmount = "0"; // Default discount amount, can be changed as needed
            order.PaymentReference = Guid.NewGuid().ToString(); // Generate a fake payment reference
            order.Notes = string.Empty; // Initialize notes, can be added later
            order.CouponCode = string.Empty; // Initialize coupon code, can be added later
            order.ImageUrls = string.Empty; // Initialize image URLs, can be added later
            order.CustomerName = "Default Customer"; // Default customer name, can be changed as needed
            return Task.FromResult(order.Id);
        }

        public Task UpdateOrderStatus(Guid OrderId, OrderStatus order)
        {
            ORDERS.Where(o => o.Id == OrderId)
                .ToList()
                .ForEach(o => o.Status = order);
            return Task.CompletedTask;
        }

        public Task<List<OrderModel>> GetOrdersByUserId(Guid userId)
        {
            ORDERS.Where(o => o.CustomerId == userId.ToString())
                .ToList();
            if (ORDERS.Count == 0)
            {
                throw new KeyNotFoundException($"No orders found for user with ID {userId}.");
            }
            return Task.FromResult(ORDERS.Where(o => o.CustomerId == userId.ToString()).ToList());
        }
    }
}
