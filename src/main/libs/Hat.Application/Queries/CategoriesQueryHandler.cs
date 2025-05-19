using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Repositories;
using MediatR;

namespace Hat.Application.Queries
{
    public class CategoriesQueryHandler : IRequestHandler<CategoriesQuery, List<CategoryModel>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryModel>> Handle(CategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategories();
        }
    }
}
