using Hat.Domain.Features.Product.Enums;
using Hat.Domain.Features.Product.Models;
using Hat.Domain.Features.Product.Types.Extended.Addon;

namespace Hat.Domain.Features.Product.Types.Extended
{
    public class ExtendedProductModel : ProductModel
    {

        #region data
        public decimal BasePrice { get; private set; }

        #endregion

        #region rich
        public override ProductType Type => ProductType.Extended;
        public ICollection<ProductAddonModel> Addons { get;  set; }

      
        public decimal CalculateTotalPrice(IEnumerable<string> selectedAddons)
        {
            var addonTotal = Addons
                .Where(a => selectedAddons.Contains(a.Name))
                .Sum(a => a.AdditionalPrice);

            return BasePrice + addonTotal;
        }
        #endregion
        public ExtendedProductModel(string name, string? description)
            : base(name, description)
        {
            Name = name;
            Description = description;
        }
        public ExtendedProductModel(string name, string? description, decimal basePrice, List<ProductAddonModel> addons)
            : this(name, description)
        {
            BasePrice = basePrice;
            Addons = addons;
        }


    }
}
