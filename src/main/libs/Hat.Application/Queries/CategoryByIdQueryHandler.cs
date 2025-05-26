using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class CategoryByIdQueryHandler : IRequestHandler<CategoryByIdQuery, CategoryModel?>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryModel?> Handle(CategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategory(request.CategoryId);
        }
    }
}
