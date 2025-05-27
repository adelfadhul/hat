using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class PrimaryShippingAddressQuery : IRequest<ShippingAddressModel>
    {
        public Guid UserId { get; set; }
        public PrimaryShippingAddressQuery(Guid userId)
        {
            UserId = userId;
        }
    }

}
