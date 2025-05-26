using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class CategoryByIdQuery : IRequest<CategoryModel?>
    {
        public Guid CategoryId { get; }
        public CategoryByIdQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
