using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class ShippingAddressesByUserQueryHandler : IRequestHandler<ShippingAddressesByUserQuery, List<ShippingAddressModel>>
    {
        private readonly IShippingAddressRepository _shippingAddressRepository;
        public ShippingAddressesByUserQueryHandler(IShippingAddressRepository shippingAddressRepository)
        {
            _shippingAddressRepository = shippingAddressRepository;
        }
        public async Task<List<ShippingAddressModel>> Handle(ShippingAddressesByUserQuery request, CancellationToken cancellationToken)
        {
            return await _shippingAddressRepository.GetShippingAddressesByUser(request.UserId);
        }
    }


}
