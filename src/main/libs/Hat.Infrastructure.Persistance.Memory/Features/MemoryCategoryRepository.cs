using Hat.Domain.Models;
using Hat.Domain.Store;
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
                new CategoryModel { Id = Guid.NewGuid(), Name = "Electronics", Icon = "\uf322" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Fashion", Icon = "\uf553" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Home", Icon = "\uf015" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Toys", Icon = "\uf1ae" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Sports", Icon = "\uf44b" }
            };
            return Task.FromResult(categories);
        }

        public Task<CategoryModel> GetCategory(string categoryId)
        {
            var categories = new List<CategoryModel>
            {
                new CategoryModel { Id = Guid.NewGuid(), Name = "Electronics", Icon = "\uf322" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Fashion", Icon = "\uf553" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Home", Icon = "\uf015" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Toys", Icon = "\uf1ae" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Sports", Icon = "\uf44b" }
            };

            var category = categories.Find(c => c.Id.ToString() == categoryId);
            return Task.FromResult(category);
        }
    }
}
