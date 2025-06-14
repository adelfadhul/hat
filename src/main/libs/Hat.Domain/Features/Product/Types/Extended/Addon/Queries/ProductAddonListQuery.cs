using MediatR;

namespace Hat.Domain.Features.Product.Types.Extended.Addon.Queries
{
    internal class ProductAddonListQuery:IRequest<List<ProductAddonModel>>
    {
    }
}
