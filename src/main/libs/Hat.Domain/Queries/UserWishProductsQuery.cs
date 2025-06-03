using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class UserWishProductsQuery : IRequest<List<ProductModel>>
    {
        public readonly Guid UserId;
        public UserWishProductsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
