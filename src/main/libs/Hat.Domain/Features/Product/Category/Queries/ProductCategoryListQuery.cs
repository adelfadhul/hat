using MediatR;

namespace Hat.Domain.Features.Product.Category.Queries
{
    public class ProductCategoryListQuery:IRequest<IEnumerable<ProductCategoryModel>>
    {
        public string? SearchTerm { get; set; } // optional search term to filter categories
       public Guid CategoryId { get; set; } // optional category ID to filter by parent category
        public ProductCategoryListQuery(Guid categoryId, string? searchTerm = null)
        {
            SearchTerm = searchTerm;
            CategoryId = categoryId;
        }
    }
}
