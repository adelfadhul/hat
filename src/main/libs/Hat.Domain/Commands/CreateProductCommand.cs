using Hat.Domain.Features.Product;
using Hat.Domain.Features.Product.Category;
using Hat.Domain.Features.Product.Enums;
using Hat.Domain.Features.Product.Types.Variable.Variation;
using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
        public double Qty { get; set; } = 1;
      
        public double VatRate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public Guid VatId { get; set; }

        public ProductType ProductType { get; set; } = ProductType.None;
        public VariationType VariationType { get; set; } = VariationType.None;

        public ICollection<ProductVariationModel> Variations { get; set; } = new List<ProductVariationModel>();
        public string DownloadUrl { get; set; } // For digital products
        public int StockQuantity { get; set; }
        public decimal WeightKg { get; set; }
        public decimal LengthCm { get; set; }
        public decimal WidthCm { get; set; }
        public decimal HeightCm { get; set; }
        public ICollection<Guid> ChildProductIds { get; set; }
        public ICollection<ProductCategoryModel> Categories { get; set; }
    }
}
