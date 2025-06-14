using Hat.Domain.Features.Product.Category;
using Hat.Domain.Features.Product.Enums;
using Hat.Domain.Features.Product.Models;

namespace Hat.Domain.Features.Product.Types.Virtual
{
    public class VirtualProductModel : ProductModel
    {
        #region data
        public decimal Price { get;  set; }
        public string? DownloadUrl { get;  set; }
        #endregion

        #region rich
        public override ProductType Type => ProductType.Virtual;

        #endregion

        public VirtualProductModel(string name,string? description, ICollection<ProductCategoryModel> categories)
            : base(name, description, categories)
        {
          
        }
        public VirtualProductModel(string name, string? description, ICollection<ProductCategoryModel> categories, decimal price, string? downloadUrl = null)
            : this( name, description,categories)
        {
            Price = price;
            DownloadUrl = downloadUrl;
        }
    }
}
