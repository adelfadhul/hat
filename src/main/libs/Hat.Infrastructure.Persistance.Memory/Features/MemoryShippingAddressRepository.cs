using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryShippingAddressRepository :UserRepository, IShippingAddressRepository
    {
        private static Lazy<List<ShippingAddressModel>> _addresses = new(() =>
        {
            return new List<ShippingAddressModel>
            {
                new ShippingAddressModel
                {
                     Id = Guid.NewGuid(),
                      UserId = Guid.NewGuid(),
                      IsPrimary = true,
                    AddressType = "Home Address",
                    FullAddress = "21, Alex Davidson Avenue, Opposite Omegatron, Vicent Smith Quarters, Victoria Island, Lagos, Nigeria",
                    Street = "21, Alex Davidson Avenue",
                    City = "Victoria Island",
                    State = "Lagos"
                },
                new ShippingAddressModel
                {
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid(),
                        IsPrimary = false,
                    AddressType = "Work Address",
                    FullAddress = "9, Martins Crescent, Bank of Nigeria, Abuja, Nigeria",
                    Street = "9, Martins Crescent",
                    City = "Abuja",
                    State = ""
                }
            };
        });

        public MemoryShippingAddressRepository(ICurrentUser currentUser) : base(currentUser)
        {
        }

        private static List<ShippingAddressModel> ADDRESSES => _addresses.Value;
        public Task<List<ShippingAddressModel>> GetShippingAddresses()
        {
            // Simulate async operation
            return Task.FromResult(ADDRESSES);
        }

        public Task<ShippingAddressModel?> GetPrimaryShippingAddress()
        {
           return Task.FromResult(ADDRESSES.FirstOrDefault(a => a.IsPrimary) ?? null);
        }

         
    }
}
