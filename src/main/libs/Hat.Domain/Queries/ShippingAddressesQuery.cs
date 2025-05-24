using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class ShippingAddressesQuery : IRequest<List<ShippingAddressModel>>
    {
    }

}
