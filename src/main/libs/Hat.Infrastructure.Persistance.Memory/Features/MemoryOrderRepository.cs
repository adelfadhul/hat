using Hat.Domain.Enums;
using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;
using Hat.Infrastructure.Identity.Memory;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryOrderRepository : UserRepository, IOrderRepository
    {
        public MemoryOrderRepository(ILoginService loginService) : base(loginService)
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
                 UserId= MemoryLoginService.UserId1,
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
                 UserId= MemoryLoginService.UserId2,
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
                 UserId= MemoryLoginService.UserId3,
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
                 UserId= MemoryLoginService.UserId1,
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
                 UserId= MemoryLoginService.UserId2,
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

        public Task CreateOrder(OrderModel order)
        {
            throw new NotImplementedException();
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
