using Hat.Domain.Models;

namespace Hat.Domain.Repositories
{
    public interface IDeliveryStepRepository
    {
        Task<List<DeliveryStepModel>> GetDeliverySteps();
    }
}
