using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class BestSellingProductsQuery : IRequest<List<ProductModel>>
    {
    }
}
