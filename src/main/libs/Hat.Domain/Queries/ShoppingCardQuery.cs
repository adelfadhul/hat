using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class ShoppingCartQuery : IRequest<List<CartItemModel>>
    {
    }

   

}
