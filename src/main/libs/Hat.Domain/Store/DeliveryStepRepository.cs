using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IDeliveryStepRepository
    {
        Task<List<DeliveryStepModel>> GetDeliverySteps();
    }
}
