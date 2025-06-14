using MediatR;

namespace Hat.Domain.Features.Product.Types.Extended.Addon.Command
{
    internal class CreateProductAddonCommand:IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public CreateProductAddonCommand(Guid productId, string name, string description, decimal? price, string imageUrl)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
        }
    }
}
