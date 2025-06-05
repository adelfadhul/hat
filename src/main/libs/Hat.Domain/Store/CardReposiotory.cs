using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface ICardRepository
    {
        Task<List<CardModel>> GetCards();
        Task<Guid> CreateCard(CardModel card);
        Task DeleteCard(string cardNumber);
    }
}
