using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class TaxByIdQuery : IRequest<TaxModel?>
    {
        public TaxByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}
