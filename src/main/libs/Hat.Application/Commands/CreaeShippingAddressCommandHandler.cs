using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    public class CreaeShippingAddressCommandHandler : IRequestHandler<CreateShippingAddressCommand, Guid>
    {
        private readonly IShippingAddressRepository _repository;
        public CreaeShippingAddressCommandHandler(IShippingAddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateShippingAddressCommand request, CancellationToken cancellationToken)
        {
            var shippingAddress = new ShippingAddressModel
            {
                IsInactive = false,
                UserId = request.UserId,
                Name = request.Name,
                Address = request.Address


            };
            return await _repository.CreateShippingAddress(shippingAddress);
        }
    }
}
