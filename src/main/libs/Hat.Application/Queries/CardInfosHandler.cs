using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class CardInfosHandler : IRequestHandler<CardInfosQuery, List<CardInfoModel>>
    {
        private readonly ICardRepository _cardInfoRepository;
        public CardInfosHandler(ICardRepository cardInfoRepository)
        {
            _cardInfoRepository = cardInfoRepository;
        }
        public async Task<List<CardInfoModel>> Handle(CardInfosQuery request, CancellationToken cancellationToken)
        {
            return await _cardInfoRepository.GetCards();
        }
    }
}
