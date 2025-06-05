using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IShippingAddressRepository
    {
        Task<List<ShippingAddressModel>> GetShippingAddresses();
        Task<ShippingAddressModel?> GetPrimaryShippingAddress();

        Task<Guid> CreateShippingAddress(ShippingAddressModel model);
        Task DeleteShippingAddress(Guid id);
        Task InactivateShippingAddress(Guid id);
        Task ActivateShippingAddress(Guid id);
    }
}
