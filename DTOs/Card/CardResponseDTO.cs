namespace FarmAZ.DTOs.Card
{
    public class CardResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CardItemResponseDto> Items { get; set; } = new();
        public decimal GrandTotal => Items.Sum(i => i.TotalPrice);
    }
}