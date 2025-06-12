using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;
using Hat.Infrastructure.Identity.Memory;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryCardRepository :  ICardRepository
    {
        public MemoryCardRepository() 
        {
        }

        public Task<Guid> CreateCard(CardModel card)
        {
            CARDS.Add(card);
            return Task.FromResult(card.Id);
        }

        public Task DeleteCard(string cardNumber)
        {
            CARDS.RemoveAll(c => c.CardNumber == cardNumber);
            return Task.CompletedTask;
        }

        private static Lazy<List<CardModel>> _cards = new(() =>
        {
           
            return new List<CardModel>
            {
                new CardModel() { UserId= MemoryLoginService.USER_Alice, CardNumber = "371449635398431", CardValidationCode = "123", ExpirationDate = "2024-12-01", IsSelected = true },
                new CardModel() {UserId= MemoryLoginService.USER_Alice, CardNumber = "38520000023237", CardValidationCode = "456", ExpirationDate = "2025-12-01" },
                new CardModel() {UserId= MemoryLoginService.USER_Bob, CardNumber = "6011000990139424", CardValidationCode = "789", ExpirationDate = "2026-12-01" },
                new CardModel() {UserId= MemoryLoginService.USER_Bob, CardNumber = "3566002020360505", CardValidationCode = "321", ExpirationDate = "2027-12-01" },
                new CardModel() { UserId= MemoryLoginService.USER_Lina,CardNumber = "5555555555554444", CardValidationCode = "654", ExpirationDate = "2028-12-01" },
                new CardModel() { UserId= MemoryLoginService.USER_Lina,CardNumber = "4012888888881881", CardValidationCode = "987", ExpirationDate = "2028-12-01" }
            };
        });

        public static List<CardModel> CARDS => _cards.Value;
        public Task<List<CardModel>> GetCards()
        {
            return Task.FromResult(CARDS);
        }

        public Task<List<CardModel>> GetCardsByUser(Guid userId)
        {
             return Task.FromResult(CARDS.Where(c => c.UserId == userId).ToList());
        }
    }
}
