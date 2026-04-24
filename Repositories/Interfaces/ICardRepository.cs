using FarmAZ.Entities;

namespace FarmAZ.Repositories.Interfaces
{
    public interface ICardRepository
    {
        Task<Card?> GetByUserIdAsync(int userId);
        Task<Card> CreateAsync(Card card);
        Task<CardItem?> GetItemAsync(int cardItemId);
        Task AddItemAsync(CardItem item);
        Task RemoveItemAsync(CardItem item);
        Task SaveChangesAsync();
    }
}