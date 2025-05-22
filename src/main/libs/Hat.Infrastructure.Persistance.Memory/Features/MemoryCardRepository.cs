using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryCardRepository : ICardRepository
    {
        public Task AddCard(CardInfoModel card)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCard(string cardNumber)
        {
            throw new NotImplementedException();
        }

        public Task<List<CardInfoModel>> GetCards()
        {

            var cards = new List<CardInfoModel>
            {
                new CardInfoModel() { CardNumber = "371449635398431", CardValidationCode = "123", ExpirationDate = "2024-12-01", IsSelected = true },
                new CardInfoModel() { CardNumber = "38520000023237", CardValidationCode = "456", ExpirationDate = "2025-12-01" },
                new CardInfoModel() { CardNumber = "6011000990139424", CardValidationCode = "789", ExpirationDate = "2026-12-01" },
                new CardInfoModel() { CardNumber = "3566002020360505", CardValidationCode = "321", ExpirationDate = "2027-12-01" },
                new CardInfoModel() { CardNumber = "5555555555554444", CardValidationCode = "654", ExpirationDate = "2028-12-01" },
                new CardInfoModel() { CardNumber = "4012888888881881", CardValidationCode = "987", ExpirationDate = "2028-12-01" }
            };

            return Task.FromResult(cards);
        }
    }
}
