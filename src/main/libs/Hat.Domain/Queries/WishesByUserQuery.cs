using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class WishesByUserQuery : IRequest<List<WishModel>>
    {
        public readonly Guid UserId;
        public WishesByUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
