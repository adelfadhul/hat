using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class ProductByIdQuery : IRequest<ProductModel?>
    {
        public Guid ProductId { get; }
        public bool IsFull { get; } 
        public ProductByIdQuery(Guid productId, bool isFull)
        {
            ProductId = productId;
            IsFull = isFull;
        }
    }
}
