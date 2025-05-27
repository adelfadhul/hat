using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryTrackRepository :UserRepository, ITrackRepository
    {
        public MemoryTrackRepository(ICurrentUser currentUser) : base(currentUser)
        {
        }

        public Task<List<TrackModel>> GetTracks()
        {
            var tracks = new List<TrackModel>
        {
            new TrackModel
            {
                OrderId = "OD - 424923192 - N",
                Price = "$4500",
                Status = "Delivered",
                ImageUrls = string.Join(",",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png"
                )
            },
            new TrackModel
            {
                OrderId = "OD - 424923192 - N",
                Price = "$500",
                Status = "Delivered",
                ImageUrls = string.Join(",",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png"
                )
            },
            new TrackModel
            {
                OrderId = "OD - 424923192 - N",
                Price = "$700",
                Status = "Delivered",
                ImageUrls = string.Join(",",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png",
                    "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png"
                )
            },
            new TrackModel
            {
                OrderId = "OD - 424923192 - N",
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
            new TrackModel
            {
                OrderId = "OD - 424923192 - N",
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

            return Task.FromResult(tracks);
        }
    }
}
