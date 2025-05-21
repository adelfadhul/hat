using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class DeliveryStepsQuery : IRequest<List<DeliveryStepModel>>
    {
    }
   
}
