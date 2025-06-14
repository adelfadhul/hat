using Hat.Domain.Features.Product.Models;

namespace Hat.Domain.Features.Product.Store
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetProducts();
        Task<List<ProductModel>> GetProductsByCategory(Guid categoryId);
        Task<ProductModel?> GetProductById(Guid productId);
        Task<Guid> CreateProduct(ProductModel model);
        Task UpdateProduct(ProductModel model);
        Task DeleteProduct(Guid productId);
    }
}
