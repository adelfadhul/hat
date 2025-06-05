using Hat.Domain.Models;
using MediatR;

namespace Hat.Application.Queries
{
    public class InventoriesByProductQuery : IRequest<List<InventoryModel>>
    {
        public Guid ProductId { get; }
        public InventoriesByProductQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
