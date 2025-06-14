using MediatR;

namespace Hat.Domain.Features.Product.Models.Queries
{
    public class ProductListQuery:IRequest<IEnumerable<ProductModel>>
    {
    }
}
