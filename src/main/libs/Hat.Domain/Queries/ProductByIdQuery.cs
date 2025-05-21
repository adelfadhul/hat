using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class ProductByIdQuery : IRequest<ProductModel?>
    {
        public Guid ProductId { get; }

        public ProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
