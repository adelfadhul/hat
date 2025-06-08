using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class CartsQuery : IRequest<List<CartModel>>
    {
        public CartsQuery()
        {
        }
    }
}
