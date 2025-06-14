using MediatR;

namespace Hat.Domain.Features.Product.Types.Variable.Variation.Commands
{
    internal class ProductVariationCommand:IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Guid> OptionSelections { get; set; } = new List<Guid>();
    }
}
