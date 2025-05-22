using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class ShippingAddressesQueryHandler:IRequestHandler<ShippingAddressesQuery, List<ShippingAddressModel>>
    {
        private readonly IShippingAddressRepository _shippingAddressRepository;
        public ShippingAddressesQueryHandler(IShippingAddressRepository shippingAddressRepository)
        {
            _shippingAddressRepository = shippingAddressRepository;
        }
        public async Task<List<ShippingAddressModel>> Handle(ShippingAddressesQuery request, CancellationToken cancellationToken)
        {
            return await _shippingAddressRepository.GetShippingAddresses();
        }
    }

    
}
