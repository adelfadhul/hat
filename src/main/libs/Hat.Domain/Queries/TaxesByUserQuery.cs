using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class TaxesByUserQuery : IRequest<List<TaxModel>>
    {
        public Guid UserId { get; set; }
        public TaxesByUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
