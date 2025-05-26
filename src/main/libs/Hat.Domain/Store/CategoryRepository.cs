using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetCategories();
        Task<CategoryModel?> GetCategory(Guid categoryId);
       
    }
}
