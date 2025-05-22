using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class DeliveryStepsQueryHandler : IRequestHandler<DeliveryStepsQuery, List<DeliveryStepModel>>
    {
        private readonly IDeliveryStepRepository _deliveryStepRepository;
        public DeliveryStepsQueryHandler(IDeliveryStepRepository deliveryStepRepository)
        {
            _deliveryStepRepository = deliveryStepRepository;
        }
        public async Task<List<DeliveryStepModel>> Handle(DeliveryStepsQuery request, CancellationToken cancellationToken)
        {
            return await _deliveryStepRepository.GetDeliverySteps();
        }
    }
}
