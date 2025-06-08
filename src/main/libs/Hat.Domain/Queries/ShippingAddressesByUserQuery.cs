using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class ShippingAddressesByUserQuery : IRequest<List<ShippingAddressModel>>
    {
        public Guid UserId { get; set; }
        public ShippingAddressesByUserQuery(Guid userId)
        {
            UserId = userId;
            // Default constructor for MediatR
        }


    }
}
