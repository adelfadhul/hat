using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    
    public interface IInventoryRepository
    {
        Task<List<InventoryModel>> GetAll();    
        Task<List<InventoryModel>> Get(Guid id);
        Task Add(InventoryModel model);
        Task Delete(Guid id);
        Task Update(InventoryModel model);

        Task<List<string>> GetColorsByProduct(Guid productId);
        Task<List<string>> GetSizesByProduct(Guid productId);

        Task<int> GetCountByProduct(Guid productId);
    }
}
