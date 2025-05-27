using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IShippingAddressRepository
    {
        Task<List<ShippingAddressModel>> GetShippingAddresses();
        Task<ShippingAddressModel?> GetPrimaryShippingAddress();
    }
}
