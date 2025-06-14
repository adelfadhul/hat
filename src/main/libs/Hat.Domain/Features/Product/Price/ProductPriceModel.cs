using Hat.Domain.Features.Product.Enums;

namespace Hat.Domain.Features.Product.Price
{
    public class ProductPriceModel
    {
        public decimal RegularPrice { get; private set; }
        public decimal? SalePrice { get; private set; }

        public DateTime? SaleStartDate { get; private set; }
        public DateTime? SaleEndDate { get; private set; }

        public TaxStatus TaxStatus { get; private set; } = TaxStatus.Taxable;
        public Guid TaxId { get; private set; } 

        public decimal EffectivePrice
        {
            get
            {
                if (SalePrice.HasValue && IsWithinSalePeriod(DateTime.UtcNow))
                    return SalePrice.Value;

                return RegularPrice;
            }
        }

        public ProductPriceModel(decimal regularPrice,
                            decimal? salePrice = null,
                            DateTime? saleStart = null,
                            DateTime? saleEnd = null,
                            TaxStatus taxStatus = TaxStatus.Taxable
                       )
        {
            RegularPrice = regularPrice;
            SalePrice = salePrice;
            SaleStartDate = saleStart;
            SaleEndDate = saleEnd;
            TaxStatus = taxStatus;
        }

        private bool IsWithinSalePeriod(DateTime now)
        {
            if (!SaleStartDate.HasValue && !SaleEndDate.HasValue)
                return true;

            if (SaleStartDate.HasValue && now < SaleStartDate.Value)
                return false;

            if (SaleEndDate.HasValue && now > SaleEndDate.Value)
                return false;

            return true;
        }
    }

}
