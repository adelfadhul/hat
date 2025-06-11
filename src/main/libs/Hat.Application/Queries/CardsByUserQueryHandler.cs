using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class CardsByUserQueryHandler : IRequestHandler<CardsByUserQuery, List<CardModel>>
    {
        private readonly ICardRepository _cardRepository;
        public CardsByUserQueryHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository
                ?? throw new ArgumentException("CardRepository must implement ICardRepository");
        }
        public async Task<List<CardModel>> Handle(CardsByUserQuery request, CancellationToken cancellationToken)
        {
            return await _cardRepository.GetCardsByUser(request.UserId);
        }
    }
}
