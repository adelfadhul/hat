using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryDeliveryStepRepository : UserRepository, IDeliveryStepRepository
    {
        public MemoryDeliveryStepRepository(ILoginService loginService) : base(loginService)
        {
        }
        private static Lazy<List<DeliveryStepModel>> _steps = new(() =>
        {
            var tracks = new List<DeliveryStepModel>
        {
                new DeliveryStepModel
                {
            Id = Guid.NewGuid(),
            OrderId= MemoryOrderRepository.Order1,
            DeliveryStatusDate = DateTime.Now.AddDays(-4),
            IsComplete = true,
            Name = "Order Placed",
            Location = "Lagos State, Nigeria",
            IsLineVisible = true
        },
        new DeliveryStepModel
        {
            Id = Guid.NewGuid(),
            OrderId= MemoryOrderRepository.Order2,
            DeliveryStatusDate = DateTime.Now.AddDays(-3),
            IsComplete = true,
            Name = "Order Confirmed",
            Location = "Lagos State, Nigeria",
            IsLineVisible = true
        },
        new DeliveryStepModel
        {
            Id = Guid.NewGuid(), 
            OrderId= MemoryOrderRepository.Order3,
            DeliveryStatusDate = DateTime.Now.AddDays(-2),
            IsComplete = true,
            Name = "Order Dispatched",
            Location = "Lagos State, Nigeria",
            IsLineVisible = true
        },
        new DeliveryStepModel
        {
            Id = Guid.NewGuid(),
            OrderId= MemoryOrderRepository.Order4,
            DeliveryStatusDate = DateTime.Now.AddDays(-1),
            IsComplete = false,
            Name = "Out for Delivery",
            Location = "Lagos State, Nigeria",
            IsLineVisible = true
        },
        new DeliveryStepModel
        {
            Id = Guid.NewGuid(),
            OrderId= MemoryOrderRepository.Order4,
            DeliveryStatusDate = DateTime.Now,
            IsComplete = false,
            Name = "Order Delivered",
            Location = "Lagos State, Nigeria",
            IsLineVisible = false
        }

        };
            return tracks;
        });

        public static List<DeliveryStepModel> STEPS => _steps.Value;
        public Task<List<DeliveryStepModel>> GetDeliverySteps(Guid OrderId)
        {

            var steps = STEPS.Where(x => x.OrderId == OrderId).ToList();

            return Task.FromResult(steps);
        }
    }
}
