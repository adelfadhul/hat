using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryInventoryRepository:UserRepository, IInventoryRepository
    {
        public MemoryInventoryRepository(ICurrentUser currentUser) : base(currentUser)
        {
        }
        public static List<InventoryModel> INVENTORIES => _inventories.Value;
        private static readonly Lazy<List<InventoryModel>> _inventories= new(() =>
        {
            var inventories = new List<InventoryModel>
            {
                new InventoryModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product1,
                    Color = "#00C569",
                    Size = "XLarge",
                },
                new InventoryModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product1,
                    Color = "#A52A2A",
                    Size = "Med",
                },

                new InventoryModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product2,
                    Color = "#A52A2A",
                    Size = "One Size"
                },
                new InventoryModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product3,
                    Color = "#FF5733",
                    Size = "Medium"
                },
                new InventoryModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product4,
                    Color = "#0000FF",
                    Size = "Large"
                }
            };
            return inventories;
        });
        public Task Add(InventoryModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InventoryModel>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InventoryModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetColorsByProduct(Guid productId)
        {
            return Task.FromResult(INVENTORIES
                .Where(i => i.ProductId == productId)
                .Select(i => i.Color)
                .Distinct()
                .ToList());
        }

        public Task<List<string>> GetSizesByProduct(Guid productId)
        {
            return Task.FromResult(INVENTORIES
                .Where(i => i.ProductId == productId)
                .Select(i => i.Size)
                .Distinct()
                .ToList());
        }

        public Task Update(InventoryModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountByProduct(Guid productId)
        {
           return Task.FromResult(INVENTORIES
                .Count(i => i.ProductId == productId));
        }
        // Implement methods for inventory management here
        // For example, methods to add, update, or delete inventory items
    }
   
}
