using Hat.Domain.Features.Product.Category;
using Hat.Domain.Features.Product.Enums;
using Hat.Domain.Features.Product.Models;
using Hat.Domain.Features.Product.Types.Variable.Variation;

namespace Hat.Domain.Features.Product.Types.Variable
{
    public class VariableProductModel : ProductModel
    {
        public override ProductType Type => ProductType.Variable;

        #region data
        public ICollection<ProductVariationModel> Variations { get;  set; }

        #endregion
        
        public VariableProductModel(string name, string? description, ICollection<ProductCategoryModel> categories)
            : base(name, description, categories)
        {
            Variations = new List<ProductVariationModel>();
        }
        public VariableProductModel(string name, string? description, ICollection<ProductCategoryModel> categories, ICollection<ProductVariationModel> variations)
            : this(name, description, categories)
        {
            Variations = variations;
        }
    }
}
