using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryDeliveryStepRepository :UserRepository, IDeliveryStepRepository
    {
        public MemoryDeliveryStepRepository(ICurrentUser currentUser) : base(currentUser)
        {
        }

        public Task<List<DeliveryStepModel>> GetDeliverySteps()
        {
           
            var deliverySteps = new List<DeliveryStepModel>
    {
        new DeliveryStepModel
        {
            Id = Guid.NewGuid(),
            DeliveryStatusDate = DateTime.Now.AddDays(-4),
            IsComplete = true,
            Name = "Order Placed",
            Location = "Lagos State, Nigeria",
            IsLineVisible = true
        },
        new DeliveryStepModel
        {
            Id = Guid.NewGuid(),
            DeliveryStatusDate = DateTime.Now.AddDays(-3),
            IsComplete = true,
            Name = "Order Confirmed",
            Location = "Lagos State, Nigeria",
            IsLineVisible = true
        },
        new DeliveryStepModel
        {
            Id = Guid.NewGuid(),
            DeliveryStatusDate = DateTime.Now.AddDays(-2),
            IsComplete = true,
            Name = "Order Dispatched",
            Location = "Lagos State, Nigeria",
            IsLineVisible = true
        },
        new DeliveryStepModel
        {
            Id = Guid.NewGuid(),
            DeliveryStatusDate = DateTime.Now.AddDays(-1),
            IsComplete = false,
            Name = "Out for Delivery",
            Location = "Lagos State, Nigeria",
            IsLineVisible = true
        },
        new DeliveryStepModel
        {
            Id = Guid.NewGuid(),
            DeliveryStatusDate = DateTime.Now,
            IsComplete = false,
            Name = "Order Delivered",
            Location = "Lagos State, Nigeria",
            IsLineVisible = false
        }
    };

            return Task.FromResult(deliverySteps);
        }
    }
}
