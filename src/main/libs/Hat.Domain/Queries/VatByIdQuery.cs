using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class VatByIdQuery : IRequest<VatModel?>
    {
        public VatByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}
