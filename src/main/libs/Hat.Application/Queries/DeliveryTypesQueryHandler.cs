using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hat.Application.Queries
{
    public class DeliveryTypesQueryHandler : IRequestHandler<DeliveryTypesQuery, List<DeliveryTypeModel>>
    {
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;

        public DeliveryTypesQueryHandler(IDeliveryTypeRepository deliveryTypeRepository)
        {
            _deliveryTypeRepository = deliveryTypeRepository;
        }

        public async Task<List<DeliveryTypeModel>> Handle(DeliveryTypesQuery request, CancellationToken cancellationToken)
        {
            return await _deliveryTypeRepository.GetDeliveryTypes();
        }
    }
}
