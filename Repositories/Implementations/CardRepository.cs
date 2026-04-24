using FarmAZ.Data;
using FarmAZ.Entities;
using FarmAZ.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmAZ.Repositories.Implementations
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context) => _context = context;

        public async Task<Card?> GetByUserIdAsync(int userId) =>
            await _context.Cards
                .Include(c => c.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

        public async Task<Card> CreateAsync(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<CardItem?> GetItemAsync(int cardItemId) =>
            await _context.CardItems.FindAsync(cardItemId);

        public async Task AddItemAsync(CardItem item)
        {
            _context.CardItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(CardItem item)
        {
            _context.CardItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}