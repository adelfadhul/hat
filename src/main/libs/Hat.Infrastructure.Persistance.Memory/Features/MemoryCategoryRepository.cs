using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryCategoryRepository :UserRepository, ICategoryRepository
    {
        private static readonly Lazy<List<CategoryModel>> _categories = new(() => new List<CategoryModel>
            {
                new CategoryModel { Id = Guid.NewGuid(), Name = "Electronics", Icon = "\uf322" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Fashion", Icon = "\uf553" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Home", Icon = "\uf015" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Toys", Icon = "\uf1ae" },
                new CategoryModel { Id = Guid.NewGuid(), Name = "Sports", Icon = "\uf44b" }
            });

        public MemoryCategoryRepository(ICurrentUser currentUser) : base(currentUser)
        {
        }

        public static List<CategoryModel> CATEGORIES => _categories.Value;
        public static Guid CATEGORY_ElectronicId => CATEGORIES.Single(c => c.Name == "Electronics").Id;
        public static Guid CATEGORY_FashionId => CATEGORIES.Single(c => c.Name == "Fashion").Id;
        public static Guid CATEGORY_HomeId => CATEGORIES.Single(c => c.Name == "Home").Id;
        public static Guid CATEGORY_ToysId => CATEGORIES.Single(c => c.Name == "Toys").Id;
        public static Guid CATEGORY_SportsId => CATEGORIES.Single(c => c.Name == "Sports").Id;

       
        public Task<List<CategoryModel>> GetCategories()
        {
            return Task.FromResult(CATEGORIES);
        }

        public Task<CategoryModel?> GetCategory(Guid categoryId)
        {
            var category = CATEGORIES.Find(c => c.Id == categoryId);
            return Task.FromResult(category);
        }
    }
}
