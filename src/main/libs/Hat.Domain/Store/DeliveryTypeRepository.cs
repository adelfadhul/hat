using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IDeliveryTypeRepository
    {
        Task<List<DeliveryTypeModel>> GetDeliveryTypes();
    }
}
