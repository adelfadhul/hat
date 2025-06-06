using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class DeliveryStepsByOrderQuery : IRequest<List<DeliveryStepModel>>
    {
        public readonly Guid OrderId;
        public DeliveryStepsByOrderQuery(Guid orderId)
        {
            OrderId = orderId;
        }

    }
   
}
