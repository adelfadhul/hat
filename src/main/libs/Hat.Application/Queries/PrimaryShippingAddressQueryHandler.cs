using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class PrimaryShippingAddressQueryHandler : IRequestHandler<PrimaryShippingAddressQuery, ShippingAddressModel?>
    {
        private readonly IShippingAddressRepository _shippingAddressRepository;
        public PrimaryShippingAddressQueryHandler(IShippingAddressRepository shippingAddressRepository)
        {
            _shippingAddressRepository = shippingAddressRepository;
        }
        public async Task<ShippingAddressModel?> Handle(PrimaryShippingAddressQuery request, CancellationToken cancellationToken)
        {
            return await _shippingAddressRepository.GetPrimaryShippingAddress();
        }
    }


}
