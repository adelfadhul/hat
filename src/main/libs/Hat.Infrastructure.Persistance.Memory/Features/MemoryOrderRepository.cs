using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryOrderRepository : UserRepository, ITrackRepository
    {
        public MemoryOrderRepository(ICurrentUser currentUser) : base(currentUser)
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
                OrderDate= new DateTime(2022,9,1,0,0,0),
                Name = "OD - 424923192 - N",
                Price = "$4500",
                Status = "Delivered",
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
                OrderDate= new DateTime(2022,9,1,0,0,0),
                Name = "OD - 424923192 - N",
                Price = "$500",
                Status = "Delivered",
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
                OrderDate= new DateTime(2022,9,1,0,0,0),
                Name = "OD - 424923192 - N",
                Price = "$700",
                Status = "Delivered",
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
                OrderDate = new DateTime(2023, 5, 2, 0, 0, 0),
                Name = "OD - 424923192 - N",
                Price = "$1500",
                Status = "Delivered",
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
                 OrderDate = new DateTime(2023, 5, 2, 0, 0, 0),
                Name = "OD - 424923192 - N",
                Price = "$2700",
                Status = "Delivered",
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

        public Task<List<OrderModel>> GetTracks()
        {

            return Task.FromResult(ORDERS);
        }
    }
}
