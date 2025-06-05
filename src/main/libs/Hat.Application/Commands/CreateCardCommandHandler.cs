using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    internal class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Guid>
    {
        private readonly ICardRepository _cardRepository;
        public CreateCardCommandHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<Guid> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.CreateCard(new CardModel
            {
                CardNumber = request.CardNumber,
                ExpirationDate = request.ExpirationDate,
                NameOnCard = request.NameOnCard,
                CardValidationCode = request.CardValidationCode,

            });

            return card;
        }
    }
}
