using MediatR;

namespace Hat.Domain.Features.Product.Types.Extended.Addon.Queries
{
    internal class  ProductAddonListByProductQuery:IRequest<List<ProductAddonModel>>
    {
        public Guid ProductId { get; set; }
    }
}
