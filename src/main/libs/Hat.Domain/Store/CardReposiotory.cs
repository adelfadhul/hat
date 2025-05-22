using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface ICardRepository
    {
        Task<List<CardInfoModel>> GetCards();
        Task AddCard(CardInfoModel card);
        Task DeleteCard(string cardNumber);
    }
}
