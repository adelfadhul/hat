using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class CartsQueryHandler : IRequestHandler<CartsQuery, List<CartModel>>
    {
        private readonly ICartRepository _cartRepository;
        public CartsQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository
                ?? throw new ArgumentException("CartRepository must implement ICartRepository");
        }

        public Task<List<CartModel>> Handle(CartsQuery request, CancellationToken cancellationToken)
        {
           return _cartRepository.GetCarts();
        }
    }
}
