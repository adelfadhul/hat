using Hat.Domain.Features.Product.Types.Extended.Addon.Enums;

namespace Hat.Domain.Features.Product.Types.Extended.Addon
{
    public class ProductAddonModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;

        public AddonInputType InputType { get; set; }

        public decimal AdditionalPrice { get; set; } // base price per unit/selection
        public bool IsRequired { get; set; }

        // Optional for selection-type
        public List<string>? Options { get; set; }  // e.g., ["Aluminum", "Copper"]

        // Optional for numeric-type
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
    }
}
