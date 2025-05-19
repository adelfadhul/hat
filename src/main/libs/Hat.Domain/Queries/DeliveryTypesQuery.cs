using System.Collections.Generic;
using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class DeliveryTypesQuery : IRequest<List<DeliveryTypeModel>>
    {
    }
}
