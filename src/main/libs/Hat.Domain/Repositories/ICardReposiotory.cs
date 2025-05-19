using Hat.Domain.Models;

namespace Hat.Domain.Repositories
{
    public interface ICardRepository
    {
        Task<List<CardInfoModel>> GetCards();
        Task AddCard(CardInfoModel card);
        Task DeleteCard(string cardNumber);
    }
}
