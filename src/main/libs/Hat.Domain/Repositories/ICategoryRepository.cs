using Hat.Domain.Models;

namespace Hat.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetCategories();
        Task<CategoryModel> GetCategory(string categoryId);
       
    }
}
