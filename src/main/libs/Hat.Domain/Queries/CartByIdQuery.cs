using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class CartByIdQuery : IRequest<Guid>
    {
        public Guid Id { get; }
        public CartByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
