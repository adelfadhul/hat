using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class ProductOptionsByProductQuery : IRequest<List<ProductModel>>
    {
        public Guid ProductId { get; }
        public ProductOptionsByProductQuery(Guid productId)
        {
            ProductId = productId;
        }

    }
}
