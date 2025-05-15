using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class ProductsQuery:IRequest<List<ProductModel>>
    {
    }
}
