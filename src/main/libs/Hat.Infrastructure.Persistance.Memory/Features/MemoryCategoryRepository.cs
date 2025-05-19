using Hat.Domain.Models;
using Hat.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryCategoryRepository : ICategoryRepository
    {
        public Task<List<CategoryModel>> GetCategories()
        {
            var categories = new List<CategoryModel>
            {
                new CategoryModel { CategoryID = 1, CategoryName = "Electronics", Icon = "\uf322" },
                new CategoryModel { CategoryID = 2, CategoryName = "Fashion", Icon = "\uf553" },
                new CategoryModel { CategoryID = 3, CategoryName = "Home", Icon = "\uf015" },
                new CategoryModel { CategoryID = 4, CategoryName = "Toys", Icon = "\uf1ae" },
                new CategoryModel { CategoryID = 5, CategoryName = "Sports", Icon = "\uf44b" }
            };
            return Task.FromResult(categories);
        }

        public Task<CategoryModel> GetCategory(string categoryId)
        {
            var categories = new List<CategoryModel>
            {
                new CategoryModel { CategoryID = 1, CategoryName = "Electronics", Icon = "\uf322" },
                new CategoryModel { CategoryID = 2, CategoryName = "Fashion", Icon = "\uf553" },
                new CategoryModel { CategoryID = 3, CategoryName = "Home", Icon = "\uf015" },
                new CategoryModel { CategoryID = 4, CategoryName = "Toys", Icon = "\uf1ae" },
                new CategoryModel { CategoryID = 5, CategoryName = "Sports", Icon = "\uf44b" }
            };

            var category = categories.Find(c => c.CategoryID.ToString() == categoryId);
            return Task.FromResult(category);
        }
    }
}
