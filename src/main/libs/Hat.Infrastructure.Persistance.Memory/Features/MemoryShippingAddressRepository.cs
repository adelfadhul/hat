using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryShippingAddressRepository : IShippingAddressRepository
    {
        public Task<List<ShippingAddressModel>> GetShippingAddresses()
        {
            // Simulate async operation
            return Task.FromResult(new List<ShippingAddressModel>
            {
                new ShippingAddressModel
                {
                    AddressType = "Home Address",
                    FullAddress = "21, Alex Davidson Avenue, Opposite Omegatron, Vicent Smith Quarters, Victoria Island, Lagos, Nigeria",
                    Street = "21, Alex Davidson Avenue",
                    City = "Victoria Island",
                    State = "Lagos"
                },
                new ShippingAddressModel
                {
                    AddressType = "Work Address",
                    FullAddress = "9, Martins Crescent, Bank of Nigeria, Abuja, Nigeria",
                    Street = "9, Martins Crescent",
                    City = "Abuja",
                    State = ""
                }
            });
        }
    }
}
