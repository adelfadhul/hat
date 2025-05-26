using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class ProductsByCategoryQuery : IRequest<List<ProductModel>>
    {
        public Guid CategoryId { get; }

        public ProductsByCategoryQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
