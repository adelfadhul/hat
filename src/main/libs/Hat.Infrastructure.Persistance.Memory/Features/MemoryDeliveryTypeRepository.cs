using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryDeliveryTypeRepository: IDeliveryTypeRepository
    {
       public Task<List<DeliveryTypeModel>> GetDeliveryTypes()
        {
            var deliveryTypes = new List<DeliveryTypeModel>
            {
                new DeliveryTypeModel
                {
                    Name = "Standard Delivery",
                    Description = "Order will be delivered between 3 - 5 business days",
                    IsSelected = true
                },
                new DeliveryTypeModel
                {
                    Name = "Next Day Delivery",
                    Description= "Place your order before 6pm and your items will be delivered the next day"
                }
            };
            return Task.FromResult(deliveryTypes);
        }

       
    }
}
