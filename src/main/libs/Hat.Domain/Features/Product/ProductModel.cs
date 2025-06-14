using Hat.Domain.Features.Product.Category;
using Hat.Domain.Features.Product.Enums;

namespace Hat.Domain.Features.Product.Models
{
    public abstract class ProductModel
    {
        #region data
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string? Description { get; protected set; }
        #endregion

        #region rich
        public abstract ProductType Type { get; }
        public ICollection<ProductCategoryModel> Categories { get;  set; } = new List<ProductCategoryModel>();
        #endregion

        protected ProductModel(string name, string? description, ICollection<ProductCategoryModel>? categories)
        {
          
            Name = name;
            Description = description;
            Categories = categories ?? new List<ProductCategoryModel>();

        }
    }
}
