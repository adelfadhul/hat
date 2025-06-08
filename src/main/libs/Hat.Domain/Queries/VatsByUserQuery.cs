using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class VatsByUserQuery : IRequest<List<VatModel>>
    {
        public Guid UserId { get; set; }
        public VatsByUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
