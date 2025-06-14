using Hat.Domain.Features.Product.Category;
using Hat.Domain.Features.Product.Enums;
using Hat.Domain.Features.Product.Models;

namespace Hat.Domain.Features.Product.Types.Physical
{

    public class PhysicalProductModel : ProductModel
    {

        #region data
        public decimal Price { get;  set; }
        public int StockQuantity { get;  set; }

        public decimal WeightKg { get; set; }
        public decimal LengthCm { get; set; }
        public decimal WidthCm { get; set; }
        public decimal HeightCm { get; set; }

        #endregion

        #region rich    
        public ProductDimensionsModel Dimensions { get; private set; }
        public override ProductType Type => ProductType.Physical;
        #endregion

        public PhysicalProductModel(string name, string? description, ICollection<ProductCategoryModel> categories)
            : base(name, description, categories)
        {
           
        }
        public PhysicalProductModel(string name,  string? description, ICollection<ProductCategoryModel> categories, decimal price, int stock,decimal weightKg, decimal lengthCm, decimal widthCm, decimal heightCm)
            : this( name, description, categories)
        {
            Price = price;
            StockQuantity = stock;
            WeightKg = weightKg;
            LengthCm = lengthCm;
            WidthCm = widthCm;
            HeightCm = heightCm;
            Dimensions = new ProductDimensionsModel
            {
                WeightKg = weightKg,
                LengthCm = lengthCm,
                WidthCm = widthCm,
                HeightCm = heightCm
            };
        }
    }
}
