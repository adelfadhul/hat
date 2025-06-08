using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class CardsByUserQuery : IRequest<List<CardModel>>
    {
        public Guid UserId { get; }
        public CardsByUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
