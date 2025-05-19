using Hat.Domain.Models;

namespace Hat.Domain.Repositories
{
    public interface IDeliveryTypeRepository
    {
        Task<List<DeliveryTypeModel>> GetDeliveryTypes();
    }
}
