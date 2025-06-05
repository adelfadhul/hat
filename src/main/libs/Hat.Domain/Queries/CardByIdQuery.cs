using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class CardByIdQuery : IRequest<CardModel>
    {
        public Guid Id { get; }
        public CardByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
