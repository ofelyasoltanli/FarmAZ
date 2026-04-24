using FarmAZ.DTOs.Card;

namespace FarmAZ.Services.Interfaces
{
    public interface ICardService
    {
        Task<CardResponseDto> GetCardAsync(int userId);
        Task<CardResponseDto> AddItemAsync(int userId, CreateCardItemDto dto);
        Task<CardResponseDto> RemoveItemAsync(int userId, int cardItemId);
        Task ClearCardAsync(int userId);
    }
}