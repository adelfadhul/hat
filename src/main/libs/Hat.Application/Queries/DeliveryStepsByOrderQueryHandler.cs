using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class DeliveryStepsByOrderQueryHandler : IRequestHandler<DeliveryStepsByOrderQuery, List<DeliveryStepModel>>
    {
        private readonly IDeliveryStepRepository _deliveryStepRepository;
        public DeliveryStepsByOrderQueryHandler(IDeliveryStepRepository deliveryStepRepository)
        {
            _deliveryStepRepository = deliveryStepRepository;
        }
        public async Task<List<DeliveryStepModel>> Handle(DeliveryStepsByOrderQuery request, CancellationToken cancellationToken)
        {
            return await _deliveryStepRepository.GetDeliverySteps(request.OrderId);
        }
    }
}
