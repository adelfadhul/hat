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
                    StreetOne = "21, Alex Davidson Avenue",
                    StreetTwo = "Opposite Omegatron, Vicent Smith Quarters",
                    City = "Victoria Island",
                    State = "Lagos"
                },
                new ShippingAddressModel
                {
                    AddressType = "Work Address",
                    FullAddress = "9, Martins Crescent, Bank of Nigeria, Abuja, Nigeria",
                    StreetOne = "9, Martins Crescent",
                    StreetTwo = "Bank of Nigeria",
                    City = "Abuja",
                    State = ""
                }
            });
        }
    }
}
