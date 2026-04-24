using FarmAZ.DTOs.Card;
using FarmAZ.Entities;
using FarmAZ.Repositories.Interfaces;
using FarmAZ.Services.Interfaces;

namespace FarmAZ.Services.Implementations
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _repo;

        public CardService(ICardRepository repo) => _repo = repo;

        public async Task<CardResponseDto> GetCardAsync(int userId)
        {
            var card = await GetOrCreateCardAsync(userId);
            return MapToDto(card);
        }

        public async Task<CardResponseDto> AddItemAsync(int userId, CreateCardItemDto dto)
        {
            var card = await GetOrCreateCardAsync(userId);

            var existing = card.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);
            if (existing != null)
            {
                existing.Quantity += dto.Quantity;
                await _repo.SaveChangesAsync();
            }
            else
            {
                var item = new CardItem
                {
                    CardId    = card.Id,
                    ProductId = dto.ProductId,
                    Quantity  = dto.Quantity
                };
                await _repo.AddItemAsync(item);
            }

            var updated = await _repo.GetByUserIdAsync(userId)
                ?? throw new KeyNotFoundException("Card not found.");

            return MapToDto(updated);
        }

        public async Task<CardResponseDto> RemoveItemAsync(int userId, int cardItemId)
        {
            var item = await _repo.GetItemAsync(cardItemId)
                ?? throw new KeyNotFoundException($"CardItem {cardItemId} not found.");

            await _repo.RemoveItemAsync(item);

            var updated = await _repo.GetByUserIdAsync(userId)
                ?? throw new KeyNotFoundException("Card not found.");

            return MapToDto(updated);
        }

        public async Task ClearCardAsync(int userId)
        {
            var card = await _repo.GetByUserIdAsync(userId);
            if (card == null) return;

            foreach (var item in card.Items.ToList())
                await _repo.RemoveItemAsync(item);
        }

        // Əgər user-in card-ı yoxdursa avtomatik yarat
        private async Task<Card> GetOrCreateCardAsync(int userId)
        {
            var card = await _repo.GetByUserIdAsync(userId);
            if (card != null) return card;

            return await _repo.CreateAsync(new Card { UserId = userId });
        }

        private static CardResponseDto MapToDto(Card card) => new()
        {
            Id     = card.Id,
            UserId = card.UserId,
            Items  = card.Items.Select(i => new CardItemResponseDto
            {
                Id          = i.Id,
                ProductId   = i.ProductId,
                ProductName = i.Product?.Name ?? "",
               Price = (decimal)(i.Product?.Price ?? 0),
                Quantity    = i.Quantity
            }).ToList()
        };
    }
}