using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class CardsQueryHandler : IRequestHandler<CardsQuery, List<CardModel>>
    {
        private readonly ICardRepository _cardInfoRepository;
        public CardsQueryHandler(ICardRepository cardInfoRepository)
        {
            _cardInfoRepository = cardInfoRepository;
        }
        public async Task<List<CardModel>> Handle(CardsQuery request, CancellationToken cancellationToken)
        {
            return await _cardInfoRepository.GetCards();
        }
    }
}
