using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryInventoryRepository :  IInventoryRepository
    {
        public MemoryInventoryRepository()
        {
        }
        public static List<InventoryModel> INVENTORIES => _inventories.Value;
        private static readonly Lazy<List<InventoryModel>> _inventories = new(() =>
        {
            var inventories = new List<InventoryModel>
            {
                new InventoryModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.PRODUCT_BeoPlaySpeaker,
                    ProductColor = "#00C569",
                    ProductSize = "XLarge",
                    SKU = "SKU-001",
                    Description = "High-quality wireless speaker with immersive sound.",
                    Location = "Warehouse A",
                    IsSold = false
                },
                new InventoryModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.PRODUCT_BeoPlaySpeaker,
                    ProductColor = "#A52A2A",
                    ProductSize = "Med",
                    SKU = "SKU-002",
                    Description = "High-quality wireless speaker with immersive sound.",
                    Location = "Warehouse B",
                    IsSold = false
                },

                new InventoryModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.PRODUCT_LeatherWristwatch,
                    ProductColor = "#A52A2A",
                    ProductSize = "One Size",
                    SKU = "SKU-003",
                    Description = "Elegant leather wristwatch for all occasions.",
                    Location = "Warehouse C",
                    IsSold = false
                },
                new InventoryModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.PRODUCT_SmartBluetoothSpeaker,
                    ProductColor = "#FF5733",
                    ProductSize = "Medium",
                    SKU = "SKU-004",
                    Description = "Smart speaker with voice assistant integration.",
                    Location = "Warehouse D",
                    IsSold = false
                },
                new InventoryModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.PRODUCT_SmartLuggage,
                    ProductColor = "#0000FF",
                    ProductSize = "Large",
                    SKU = "SKU-005",
                    Description = "Stylish and comfortable sofa for your living room.",
                    Location = "Warehouse E",
                    IsSold = false
                }
            };
            return inventories;
        });
        public async Task<Guid> Create(InventoryModel model)
        {
            INVENTORIES.Add(model);
            await Task.CompletedTask;
            return model.Id;
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
                .Select(i => i.ProductColor)
                .Distinct()
                .ToList());
        }

        public Task<List<string>> GetSizesByProduct(Guid productId)
        {
            return Task.FromResult(INVENTORIES
                .Where(i => i.ProductId == productId)
                .Select(i => i.ProductSize)
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
