using MediatR;

namespace Hat.Domain.Features.Product.Models.Queries
{
    public class ProductListByCategoryQuery : IRequest<IEnumerable<ProductModel>>
    {
        public Guid CategoryId { get; set; }
        public ProductListByCategoryQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
